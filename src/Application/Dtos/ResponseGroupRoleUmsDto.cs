// -----------------------------------------------------------------------------------
// ResponseGroupRoleUmsDto.cs 2023
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace MSCoip.Application.Dtos;

#pragma warning disable

public record ResponseGroupRoleUmsVm
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public List<ResponseGroupRoleUms> ResponseGroups { get; set; }
}

public record ResponseGroupRoleUms
{
    public string Name { get; set; }
    public List<string> ItemList { get; set; }
    public ResponseGroupRoleUmsDto Response { get; set; }
}

public record ResponseGroupRoleUmsDto
{
    public string Request { get; set; }
    public string Status { get; set; }
}
