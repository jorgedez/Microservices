namespace Web.Shopping.HttpAggregator.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Web.Shopping.HttpAggregator.Models;

    public interface ICatalogService
    {
        Task<CatalogItem> GetCatalogItemAsync(int id);

        Task<IEnumerable<CatalogItem>> GetCatalogItemsAsync(IEnumerable<int> ids);
    }
}
