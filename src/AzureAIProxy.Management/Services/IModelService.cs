using AzureAIProxy.Management.Components.ModelManagement;

namespace AzureAIProxy.Management.Services;

public interface IModelService
{
    Task<OwnerCatalog> AddOwnerCatalogAsync(ModelEditorModel model);
    Task DeleteOwnerCatalogAsync(Guid catalogId);
    Task<IEnumerable<OwnerCatalog>> GetOwnerCatalogsAsync();
    Task<OwnerCatalog?> GetOwnerCatalogAsync(Guid catalogId);
    Task UpdateOwnerCatalogAsync(OwnerCatalog ownerCatalog);
    Task DuplicateOwnerCatalogAsync(OwnerCatalog ownerCatalog);
    Task<ModelConnectionValidation> ValidateOwnerCatalogAsync(Guid catalogId);
}

public record ModelConnectionValidation(bool IsReachable, string Message);
