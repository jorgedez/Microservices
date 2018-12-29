namespace Catalog.API.IntegrationEvents.EventHandling
{
    using Catalog.API.IntegrationEvents.Events;
    using EventBus.Abstractions;
    using Infrastructure;
    using System.Threading.Tasks;

    public class OrderStatusChangedToPaidIntegrationEventHandler : 
        IIntegrationEventHandler<OrderStatusChangedToPaidIntegrationEvent>
    {
        private readonly CatalogContext _catalogContext;

        public OrderStatusChangedToPaidIntegrationEventHandler(CatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }

        public async Task Handle(OrderStatusChangedToPaidIntegrationEvent command)
        {
            //we're not blocking stock/inventory
            foreach (var orderStockItem in command.OrderStockItems)
            {
                var catalogItem = _catalogContext.CatalogItems.Find(orderStockItem.ProductId);

                catalogItem.RemoveStock(orderStockItem.Units);
            }

            await _catalogContext.SaveChangesAsync();
        }
    }
}