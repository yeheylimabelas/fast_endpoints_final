// -----------------------------------------------------------------------------------
// ResponsePermissionUmsDto.cs 2023
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace MSCoip.Application.Dtos;

#pragma warning disable
public record ResponsePermissionUmsVm
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public List<ResponsePermissionUmsDto> ResponsePermissionDtos { get; set; }
}

public record ResponsePermissionUmsDto
{
    public string Name { get; set; }
    public string Status { get; set; }
}
