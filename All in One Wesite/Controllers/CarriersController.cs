using All_in_One_Wesite.Models;
using Microsoft.AspNetCore.Mvc;

namespace All_in_One_Wesite.Controllers
{
    public class CarriersController : Microsoft.AspNetCore.Mvc.Controller
    {
        public IActionResult Carriers()
        {
            if (DataModel.Paslogin)
            {
                return View();
            }
            else
            {
                return RedirectToRoute(new { controller = "Home", action = "UnAutherize" });
            }
        }
        public IActionResult ContainerPKL()
        {
            if (DataModel.Paslogin)
            {
                return View();
            }
            else
            {
                return RedirectToRoute(new { controller = "Home", action = "UnAutherize" });
            }
        }
    }
}
