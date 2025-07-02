using Microsoft.AspNetCore.Mvc;

namespace RadFBApp.Areas.User.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
