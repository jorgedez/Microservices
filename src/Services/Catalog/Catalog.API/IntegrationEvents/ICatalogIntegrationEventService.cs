namespace Catalog.API.IntegrationEvents
{
    using EventBus.Events;
    using System.Threading.Tasks;

    public interface ICatalogIntegrationEventService
    {
        Task SaveEventAndCatalogContextChangesAsync(IntegrationEvent evt);
        Task PublishThroughEventBusAsync(IntegrationEvent evt);
    }
}
