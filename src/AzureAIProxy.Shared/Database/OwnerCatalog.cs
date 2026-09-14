namespace AzureAIProxy.Shared.Database;

public class OwnerCatalog
{
    public string OwnerId { get; set; } = null!;
    public Guid CatalogId { get; set; }
    public string DeploymentName { get; set; } = null!;
    public string EndpointUrl { get; set; } = null!;
    public string EndpointKey { get; set; } = null!;
    public bool Active { get; set; }
    public ModelType? ModelType { get; set; }
    public string Location { get; set; } = null!;
    public string FriendlyName { get; set; } = null!;
    public bool UseManagedIdentity { get; set; }
    public bool UseMaxCompletionTokens { get; set; }
    public List<Event> Events { get; set; } = [];

    public IReadOnlyList<string> Capabilities => ModelType switch
    {
        global::AzureAIProxy.Shared.Database.ModelType.Azure_AI_Search => ["Search"],
        global::AzureAIProxy.Shared.Database.ModelType.Foundry_Agent => ["Agents", "Responses"],
        global::AzureAIProxy.Shared.Database.ModelType.MCP_Server => ["MCP"],
        global::AzureAIProxy.Shared.Database.ModelType.Foundry_Toolkit => ["Chat"],
        global::AzureAIProxy.Shared.Database.ModelType.Foundry_Model when DeploymentName.Contains("embedding", StringComparison.OrdinalIgnoreCase) => ["Embeddings"],
        global::AzureAIProxy.Shared.Database.ModelType.Foundry_Model => ["Chat", "Responses"],
        _ => []
    };
}
