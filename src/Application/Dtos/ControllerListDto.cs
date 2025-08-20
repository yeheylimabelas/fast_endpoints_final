// -----------------------------------------------------------------------------------
// ControllerListDto.cs 2023
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using System.Collections.Generic;

namespace MSCoip.Application.Dtos;

#pragma warning disable
public record ControllerListDto
{
    public string Controller { get; set; }
    public string Action { get; set; }
    public string Url { get; set; }
    public string Method { get; set; }
    public List<string> Groups { get; set; }
    public List<string> Role { get; set; }
}
