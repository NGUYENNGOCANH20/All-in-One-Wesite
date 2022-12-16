using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
