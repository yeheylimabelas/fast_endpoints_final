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
/// CreatePermissionCommand
/// </summary>
public class CreatePermissionCommand : ICommand<DocumentRootJson<ResponsePermissionUmsVm>>
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
/// Handling CreatePermissionCommand
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="CreatePermissionCommandHandler"/> class.
/// </remarks>
/// <param name="_userAuthorizationService">Set userAuthorizationService to get User's Attributes</param>
public class CreatePermissionCommandHandler(IUserAuthorizationService _userAuthorizationService)
    : ICommandHandler<CreatePermissionCommand, DocumentRootJson<ResponsePermissionUmsVm>>
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
    /// <returns>Add permission to UMS</returns>
    public async Task<DocumentRootJson<ResponsePermissionUmsVm>> ExecuteAsync(
        CreatePermissionCommand command,
        CancellationToken ct)
    {
        var permissionList = new List<PermissionDto>();

        foreach (var item in command.ControllerList)
        {
            permissionList.Add(
                new PermissionDto
                {
                    ServiceId = command.ServiceId,
                    PermissionCode = $"{item.Controller}_{item.Action}",
                    Path = item.Url,
                    PostStatus = item.Method.Equals("POST") ? true : null,
                    GetStatus = item.Method.Equals("GET") ? true : null,
                    PutStatus = item.Method.Equals("PUT") ? true : null,
                    DeleteStatus = item.Method.Equals("DELETE") ? true : null,
                    PatchStatus = item.Method.Equals("PATCH") ? true : null
                });
        }

        permissionList = permissionList
            .GroupBy(x => x.PermissionCode)
            .Select(x =>
            {
                var permission = x.FirstOrDefault();

                foreach (var permissionx in x)
                {
                    permission = permission with
                    {
                        PostStatus = permission.PostStatus ?? permissionx.PostStatus,
                        GetStatus = permission.GetStatus ?? permissionx.GetStatus,
                        PutStatus = permission.PutStatus ?? permissionx.PutStatus,
                        DeleteStatus = permission.DeleteStatus ?? permissionx.DeleteStatus,
                        PatchStatus = permission.PatchStatus ?? permissionx.PatchStatus
                    };
                }

                return permission;
            })
            .ToList();

        var response = await _userAuthorizationService
            .CreatePermissionsAsync(command.ApplicationId, permissionList, ct)
            .ConfigureAwait(false);

        var result = new ResponsePermissionUmsVm { ResponsePermissionDtos = response };

        return JsonApiExtensions.ToJsonApi(result);
    }
}
