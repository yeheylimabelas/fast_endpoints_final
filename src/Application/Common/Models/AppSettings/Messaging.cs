using System.Collections.Generic;
using MSCoip.Domain.Constants;

namespace MSCoip.Application.Common.Models.AppSettings;

/// <summary>
/// Messaging
/// </summary>
public class Messaging
{
    /// <summary>
    /// Gets or sets azureEventHub
    /// </summary>
    /// <value></value>
    public List<AzureEventHub> AzureEventHub { get; set; } = new List<AzureEventHub>();

    /// <summary>
    /// Gets or sets configuration
    /// </summary>
    /// <value></value>
    public Configuration Configuration { get; set; }
}

/// <summary>
/// AzureEventHub
/// </summary>
public class AzureEventHub
{
    /// <summary>
    /// Gets or sets name
    /// </summary>
    /// <value></value>
    public string Name { get; set; } = "dca";

    /// <summary>
    /// Gets or sets connectionString
    /// </summary>
    /// <value></value>
    public string ConnectionString { get; set; } = "DCA_Tracking_Service";

    /// <summary>
    /// Gets or sets storageAccount
    /// </summary>
    /// <value></value>
    public string StorageAccount { get; set; } = "DCA_Tracking_Service";

    /// <summary>
    /// Gets or sets blobContainerName
    /// </summary>
    /// <value></value>
    public string BlobContainerName { get; set; } = "DCA_Tracking_Service";

    /// <summary>
    /// Gets or sets topic
    /// </summary>
    /// <value></value>
    public List<EventHubTopic> Topics { get; set; } = new List<EventHubTopic>();
}

/// <summary>
/// EventHubTopic
/// </summary>
public class EventHubTopic
{
    /// <summary>
    /// Gets or sets name
    /// </summary>
    /// <value></value>
    public string Name { get; set; } = "dca_assignmentservice_assignments_v1";

    /// <summary>
    /// Gets or sets groupName
    /// </summary>
    /// <value></value>
    public string GroupName { get; set; } = "$Default";

    /// <summary>
    /// Gets or sets value
    /// </summary>
    /// <value></value>
    public string Value { get; set; } = "dca_assignmentservice_assignments_v1";
}

/// <summary>
/// Configuration
/// </summary>
public class Configuration
{
    /// <summary>
    /// Gets or sets maximum retries
    /// </summary>
    public int MaximumRetries { get; set; } = 4;

    /// <summary>
    /// Gets or sets delay in milliseconds
    /// </summary>
    public int Delay { get; set; } = 1000;

    /// <summary>
    /// Gets or sets delay in seconds
    /// </summary>
    public int MaximumDelay { get; set; } = 30;

    /// <summary>
    /// Gets or sets try timeout in seconds
    /// </summary>
    public int TryTimeout { get; set; } = 60;

    /// <summary>
    /// Gets or sets a value indicating whether saveToDb For Debug Message
    /// </summary>
    /// <value></value>
    public bool SaveToDb { get; set; } = true;

    /// <summary>
    /// Gets or sets max data
    /// </summary>
    /// <value></value>
    public int MaxData { get; set; } = EngineSystemConstants.MaxData;

    /// <summary>
    /// Gets or sets message To Process
    /// </summary>
    /// <value></value>
    public int MessageToProcess { get; set; } = 25;
}
