using Microsoft.AspNetCore.Mvc;

namespace JeansStyle.API.Controllers
{
    public class UserController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
