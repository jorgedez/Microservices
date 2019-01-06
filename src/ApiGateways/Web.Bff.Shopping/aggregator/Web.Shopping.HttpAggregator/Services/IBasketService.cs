namespace Web.Shopping.HttpAggregator.Services
{
    using System.Threading.Tasks;
    using Web.Shopping.HttpAggregator.Models;

    public interface IBasketService
    {
        Task<BasketData> GetByIdAsync(string id);

        Task UpdateAsync(BasketData currentBasket);
    }
}
