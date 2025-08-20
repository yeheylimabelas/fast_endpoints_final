// -----------------------------------------------------------------------------------
// MyControllerProcessor.cs 2023
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using MSCoip.Api.Controllers;
using NSwag.Generation.Processors;
using NSwag.Generation.Processors.Contexts;

namespace MSCoip.Api.Infrastructures.Processors;

/// <summary>
/// MyControllerProcessor
/// </summary>
public class MyControllerProcessor : IOperationProcessor
{
    /// <summary>
    /// Process
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public bool Process(OperationProcessorContext context)
    {
        return context.ControllerType != typeof(DevelopmentController);
    }
}
