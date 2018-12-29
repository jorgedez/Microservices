namespace Catalog.API.IntegrationEvents.EventHandling
{
    using EventBus.Abstractions;
    using EventBus.Events;
    using global::Catalog.API.IntegrationEvents;
    using Infrastructure;
    using IntegrationEvents.Events;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class OrderStatusChangedToAwaitingValidationIntegrationEventHandler :
        IIntegrationEventHandler<OrderStatusChangedToAwaitingValidationIntegrationEvent>
    {
        private readonly CatalogContext _catalogContext;
        private readonly ICatalogIntegrationEventService _catalogIntegrationEventService;

        public OrderStatusChangedToAwaitingValidationIntegrationEventHandler(CatalogContext catalogContext,
            ICatalogIntegrationEventService catalogIntegrationEventService)
        {
            _catalogContext = catalogContext;
            _catalogIntegrationEventService = catalogIntegrationEventService;
        }

        public async Task Handle(OrderStatusChangedToAwaitingValidationIntegrationEvent command)
        {
            var confirmedOrderStockItems = new List<ConfirmedOrderStockItem>();

            foreach (var orderStockItem in command.OrderStockItems)
            {
                var catalogItem = _catalogContext.CatalogItems.Find(orderStockItem.ProductId);
                var hasStock = catalogItem.AvailableStock >= orderStockItem.Units;
                var confirmedOrderStockItem = new ConfirmedOrderStockItem(catalogItem.Id, hasStock);

                confirmedOrderStockItems.Add(confirmedOrderStockItem);
            }

            var confirmedIntegrationEvent = confirmedOrderStockItems.Any(c => !c.HasStock)
                ? (IntegrationEvent)new OrderStockRejectedIntegrationEvent(command.OrderId, confirmedOrderStockItems)
                : new OrderStockConfirmedIntegrationEvent(command.OrderId);

            await _catalogIntegrationEventService.SaveEventAndCatalogContextChangesAsync(confirmedIntegrationEvent);
            await _catalogIntegrationEventService.PublishThroughEventBusAsync(confirmedIntegrationEvent);
        }
    }
}