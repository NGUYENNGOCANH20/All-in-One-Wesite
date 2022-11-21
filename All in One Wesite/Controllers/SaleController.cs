using All_in_One_Wesite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace All_in_One_Wesite.Controllers
{
    public class SaleController : Microsoft.AspNetCore.Mvc.Controller
    {
        
        public IActionResult Sale()
        {
            if (DataModel.Paslogin && DataModel.username == "Log_Anh")
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
