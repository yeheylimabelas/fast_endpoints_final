using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MSCoip.Application.Common.Extensions;
using MSCoip.Application.Common.Interfaces;
using MSCoip.Application.Dtos;

namespace MSCoip.Application.Development.Commands;

/// <summary>
/// CreateGroupCommand
/// </summary>
public class CreateGroupCommand : ICommand<DocumentRootJson<ResponseGroupRoleUmsVm>>
{
    /// <summary>
    /// Gets or sets ServiceId
    /// </summary>
    [BindRequired]
    public Guid ServiceId { get; set; }

    /// <summary>
    /// Gets or sets ApplicationId
    /// </summary>
    [BindRequired]
    public Guid ApplicationId { get; set; }

    /// <summary>
    /// Gets or sets ControllerList
    /// </summary>
    [BindRequired]
    public List<ControllerListDto> ControllerList { get; set; }
}

/// <summary>
/// Handling CreateGroupCommand
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="CreateGroupCommandHandler"/> class.
/// </remarks>
/// <param name="_userAuthorizationService">Set userAuthorizationService to get User's Attributes</param>
public class CreateGroupCommandHandler(IUserAuthorizationService _userAuthorizationService)
    : ICommandHandler<CreateGroupCommand, DocumentRootJson<ResponseGroupRoleUmsVm>>
{
    /// <summary>
    /// ExecuteAsync
    /// </summary>
    /// <param name="command">
    /// The encapsulated request body
    /// </param>
    /// <param name="ct">
    /// The cancellation token to perform cancel the operation
    /// </param>
    /// <returns>Add permission Group to UMS</returns>
    public async Task<DocumentRootJson<ResponseGroupRoleUmsVm>> ExecuteAsync(
        CreateGroupCommand command,
        CancellationToken ct)
    {
        var permissionList = await _userAuthorizationService
            .GetPermissionListAsync(command.ApplicationId, ct)
            .ConfigureAwait(false);
        var groupList = await _userAuthorizationService
            .GetGroupListAsync(command.ApplicationId, ct)
            .ConfigureAwait(false);

        var groupNameList = command
            .ControllerList
            .SelectMany(x => x.Groups)
            .Distinct()
            .OrderBy(x => x)
            .ToList();

        var responseGroups = new List<ResponseGroupRoleUms>();

        foreach (var groupName in groupNameList)
        {
            var permissionIds = new List<Guid>();
            var controllerMethodList = command
                .ControllerList
                .Where(x => x.Groups.Contains(groupName))
                .ToList();

            foreach (var item in controllerMethodList)
            {
                var permissionId = permissionList
                    .Where(
                        x =>
                            x.PermissionCode == $"{item.Controller}_{item.Action}"
                            && x.RequestType.ToLower().Equals(item.Method.ToLower())
                            && x.Service.ServiceId.Equals(command.ServiceId))
                    .Select(x => x.PermissionId)
                    .ToList();

                permissionIds.AddRange(permissionId);
            }

            var groupId = groupList
                .Where(x => x.GroupCode.ToLower().Contains(groupName.ToLower()))
                .Select(x => x.GroupId)
                .FirstOrDefault();

            var response = await _userAuthorizationService
                .CreateGroupAsync(
                    command.ApplicationId,
                    groupName,
                    groupId,
                    permissionIds,
                    ct)
                .ConfigureAwait(false);

            var actionList = controllerMethodList.Select(x => x.Action).ToList();

            responseGroups.Add(
                new ResponseGroupRoleUms
                {
                    Name = groupName,
                    ItemList = actionList,
                    Response = response
                });
        }

        var result = new ResponseGroupRoleUmsVm { ResponseGroups = responseGroups };

        return JsonApiExtensions.ToJsonApi(result);
    }
}
