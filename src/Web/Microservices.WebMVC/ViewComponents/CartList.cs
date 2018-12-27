namespace Microservices.WebMVC.ViewComponents
{
    using Microservices.WebMVC.Services;
    using Microservices.WebMVC.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using Polly.CircuitBreaker;
    using System.Threading.Tasks;

    public class CartList : ViewComponent
    {
        private readonly IBasketService _cartSvc;

        public CartList(IBasketService cartSvc) => _cartSvc = cartSvc;

        public async Task<IViewComponentResult> InvokeAsync(ApplicationUser user)
        {
            var vm = new Basket();
            try
            {
                vm = await GetItemsAsync(user);
                return View(vm);
            }
            catch (BrokenCircuitException)
            {
                // Catch error when Basket.api is in circuit-opened mode                 
                ViewBag.BasketInoperativeMsg = "Basket Service is inoperative, please try later on. (Business Msg Due to Circuit-Breaker)";
            }

            return View(vm);
        }

        private Task<Basket> GetItemsAsync(ApplicationUser user) => _cartSvc.GetBasket(user);
    }
}
