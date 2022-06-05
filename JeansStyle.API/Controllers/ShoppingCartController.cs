using Microsoft.AspNetCore.Mvc;

namespace JeansStyle.WEB.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
