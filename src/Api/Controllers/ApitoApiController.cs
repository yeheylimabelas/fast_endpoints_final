// -----------------------------------------------------------------------------------
// ApitoApiController.cs 2023
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using Microsoft.AspNetCore.Mvc;

namespace MSCoip.Api.Controllers;

/// <summary>
/// Represents RESTful of ApitoApi
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/apitoapi")]
public class ApitoApiController : ApiControllerBase
{
}
