// -----------------------------------------------------------------------------------
// DevelopmentController.cs 2023
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using System.Net;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MSCoip.Api.Infrastructures.Extensions;
using MSCoip.Api.Infrastructures.Filters;
using MSCoip.Application.Common.Extensions;
using MSCoip.Application.Development.Commands;
using MSCoip.Application.Dtos;
using MSCoip.Domain.Constants;
using NSwag.Annotations;

namespace MSCoip.Api.Controllers;

/// <summary>
/// Represents RESTful of DevelopmentController
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/development")]
[ServiceFilter(typeof(ApiDevelopmentFilterAttribute))]
public class DevelopmentController : ApiControllerBase
{
    /// <summary>
    /// Create Permissions UMS
    /// </summary>
    /// <param name="applicationId"></param>
    /// <param name="serviceId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("permissions/{applicationId}")]
    [Produces(HeaderConstants.Json)]
    [SwaggerResponse(HttpStatusCode.OK, typeof(Unit), Description = "Successfully to Create Permissions UMS")]
    [SwaggerResponse(HttpStatusCode.BadRequest, typeof(Unit), Description = ApiConstants.ApiErrorDescription.BadRequest)]
    [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(Unit), Description = ApiConstants.ApiErrorDescription.Unauthorized)]
    [SwaggerResponse(HttpStatusCode.Forbidden, typeof(Unit), Description = ApiConstants.ApiErrorDescription.Forbidden)]
    [SwaggerResponse(HttpStatusCode.InternalServerError, typeof(Unit), Description = ApiConstants.ApiErrorDescription.InternalServerError)]
    public async Task<DocumentRootJson<ResponsePermissionUmsVm>> CreatePermissionsUms(
        [BindRequired] Guid applicationId, [FromQuery][BindRequired] Guid serviceId, CancellationToken cancellationToken)
    {
        var controllerActionList = ControllerExtension.GetControllerList();

        var command = new CreatePermissionCommand
        {
            ApplicationId = applicationId,
            ServiceId = serviceId,
            ControllerList = controllerActionList
        };

        return await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Create Groups UMS
    /// </summary>
    /// <param name="applicationId"></param>
    /// <param name="serviceId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("groups/{applicationId}")]
    [Produces(HeaderConstants.Json)]
    [SwaggerResponse(HttpStatusCode.OK, typeof(Unit), Description = "Successfully to Create Groups UMS")]
    [SwaggerResponse(HttpStatusCode.BadRequest, typeof(Unit), Description = ApiConstants.ApiErrorDescription.BadRequest)]
    [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(Unit), Description = ApiConstants.ApiErrorDescription.Unauthorized)]
    [SwaggerResponse(HttpStatusCode.Forbidden, typeof(Unit), Description = ApiConstants.ApiErrorDescription.Forbidden)]
    [SwaggerResponse(HttpStatusCode.InternalServerError, typeof(Unit), Description = ApiConstants.ApiErrorDescription.InternalServerError)]
    public async Task<DocumentRootJson<ResponseGroupRoleUmsVm>> CreateGroupsUms(
        [BindRequired] Guid applicationId, [FromQuery][BindRequired] Guid serviceId, CancellationToken cancellationToken)
    {
        var controllerActionList = ControllerExtension.GetControllerList();

        var command = new CreateGroupCommand
        {
            ApplicationId = applicationId,
            ServiceId = serviceId,
            ControllerList = controllerActionList
        };

        return await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Create Roles UMS
    /// </summary>
    /// <param name="applicationId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("roles/{applicationId}")]
    [Produces(HeaderConstants.Json)]
    [SwaggerResponse(HttpStatusCode.OK, typeof(Unit), Description = "Successfully to Create Roles UMS")]
    [SwaggerResponse(HttpStatusCode.BadRequest, typeof(Unit), Description = ApiConstants.ApiErrorDescription.BadRequest)]
    [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(Unit), Description = ApiConstants.ApiErrorDescription.Unauthorized)]
    [SwaggerResponse(HttpStatusCode.Forbidden, typeof(Unit), Description = ApiConstants.ApiErrorDescription.Forbidden)]
    [SwaggerResponse(HttpStatusCode.InternalServerError, typeof(Unit), Description = ApiConstants.ApiErrorDescription.InternalServerError)]
    public async Task<DocumentRootJson<ResponseGroupRoleUmsVm>> CreateRolesUms(
        [BindRequired] Guid applicationId, CancellationToken cancellationToken)
    {
        var controllerActionList = ControllerExtension.GetControllerList();

        var command = new CreateRoleCommand
        {
            ApplicationId = applicationId,
            ControllerList = controllerActionList
        };

        return await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
    }
}
