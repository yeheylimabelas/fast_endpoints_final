using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MSCoip.Application.Common.Extensions;
using MSCoip.Application.Common.Interfaces;
using MSCoip.Application.Common.Models;
using MSCoip.Application.Dtos;

namespace MSCoip.Application.Development.Commands;

/// <summary>
/// CreateRoleCommand
/// </summary>
public class CreateRoleCommand : ICommand<DocumentRootJson<ResponseGroupRoleUmsVm>>
{
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
/// Handling CreateActivityMasterCommand
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="AddPermissionRoleCommandHandler"/> class.
/// </remarks>
/// <param name="_userAuthorizationService">Set userAuthorizationService to get User's Attributes</param>
/// <param name="_appSetting">Set dateTime to get Application Setting</param>
public class AddPermissionRoleCommandHandler(
    IUserAuthorizationService _userAuthorizationService,
    AppSetting _appSetting
) : ICommandHandler<CreateRoleCommand, DocumentRootJson<ResponseGroupRoleUmsVm>>
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
        CreateRoleCommand command,
        CancellationToken ct)
    {
        var roleSettingList = _appSetting.AuthorizationServer.Role;
        var roleList = await _userAuthorizationService
            .GetRoleListAsync(command.ApplicationId, ct)
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

        var responsePermission = new List<ResponseGroupRoleUms>();

        foreach (var itemRole in roleSettingList)
        {
            var isGroupValid = true;

            itemRole.Group = itemRole.Group.Distinct().ToList();

            var isAllGroup = itemRole.Group.Contains("*");

            if (!isAllGroup)
            {
                isGroupValid = groupNameList.TrueForAll(itemRole.Group.Contains);
            }

            var groupIds = itemRole.Group.Contains("*")
                ? groupList
                    .Where(x => groupNameList.Contains(x.GroupCode))
                    .Select(x => x.GroupId ?? Guid.Empty)
                    .ToList()
                : groupList
                    .Where(x => itemRole.Group.Contains(x.GroupCode))
                    .Select(x => x.GroupId ?? Guid.Empty)
                    .ToList();

            isGroupValid &= isAllGroup
                ? groupIds.Count == groupNameList.Count
                : groupIds.Count == itemRole.Group.Count;

            if (!isGroupValid)
            {
                responsePermission.Add(
                    new ResponseGroupRoleUms
                    {
                        Name = itemRole.Name,
                        ItemList = itemRole.Group,
                        Response = new ResponseGroupRoleUmsDto
                        {
                            Request = "Failed",
                            Status = "One or more group is not exist or same as in AppSetting"
                        }
                    });

                continue;
            }

            var roleId = roleList
                .Where(x => x.RoleCode.ToLower().Contains(itemRole.Name.ToLower()))
                .Select(x => x.RoleId)
                .FirstOrDefault();

            var response = await _userAuthorizationService
                .CreateRoleAsync(
                    command.ApplicationId,
                    itemRole.Name,
                    roleId,
                    groupIds,
                    ct)
                .ConfigureAwait(false);

            responsePermission.Add(
                new ResponseGroupRoleUms
                {
                    Name = itemRole.Name,
                    ItemList = itemRole.Group,
                    Response = response
                });
        }

        var result = new ResponseGroupRoleUmsVm { ResponseGroups = responsePermission };

        return JsonApiExtensions.ToJsonApi(result);
    }
}
