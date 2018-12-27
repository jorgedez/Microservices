namespace Microservices.WebMVC.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ErrorController : Controller
    {
        public IActionResult Error() => View();
    }
}
