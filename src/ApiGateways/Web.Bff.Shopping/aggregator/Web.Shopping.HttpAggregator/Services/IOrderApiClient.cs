namespace Web.Shopping.HttpAggregator.Services
{
    using System.Threading.Tasks;
    using Web.Shopping.HttpAggregator.Models;

    public interface IOrderApiClient
    {
        Task<OrderData> GetOrderDraftFromBasketAsync(BasketData basket);
    }
}
