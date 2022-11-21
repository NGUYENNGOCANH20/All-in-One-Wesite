using All_in_One_Wesite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Data.SqlClient;

namespace All_in_One_Wesite.Controllers
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        public IActionResult Home()
        {
            DataModel model = new DataModel();
            ViewData["list"] = model.saletotal;
            ViewData["username"] = DataModel.username;
            return View();
        }
        public IActionResult UnAutherize()
        {
            if (DataModel.Paslogin)
            {
                ViewData["LinkMgs"] = "Home";
            }
            else
            {
                ViewData["LinkMgs"] = "Login";
            }
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}