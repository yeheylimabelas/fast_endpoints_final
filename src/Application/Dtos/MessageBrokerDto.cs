// -----------------------------------------------------------------------------------
// MessageBrokerDto.cs 2023
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

namespace MSCoip.Application.Dtos;

#pragma warning disable
public record MessageBrokerDto
{
    public string Name { get; set; }
    public string Value { get; set; }
}
