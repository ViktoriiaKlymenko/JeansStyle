using Microsoft.AspNetCore.Mvc;

namespace JeansStyle.WEB.Controllers
{
    public class UserController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }


    }
}
