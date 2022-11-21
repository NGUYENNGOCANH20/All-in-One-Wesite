using All_in_One_Wesite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using static All_in_One_Wesite.Models.DataModel;

namespace All_in_One_Wesite.Controllers
{
    public class SpanxController : Microsoft.AspNetCore.Mvc.Controller
    {
        public IActionResult Spanx()
        {
            
            if (DataModel.username == "BU_Team")
            {
                return RedirectToRoute(new { controller = "Spanx", action = "_Bu_Checking" });
            }
            else
            {
                if (DataModel.Paslogin)
                {
                    DataModel model = new DataModel();
                    ServiceCollection services = new ServiceCollection();
                    services.AddScoped<Scmvhttp, Scmvhttp>();
                    services.AddScoped<Topsystem, Topsystem>();
                    var serviceprovider = services.BuildServiceProvider();
                    ViewData["Scm"] = serviceprovider.GetService<Scmvhttp>();
                    ViewBag.Topsystem = serviceprovider.GetService<Topsystem>();
                    ViewData["display"] = "none";
                    ViewData["Sts"] = model.datasts;
                    if (DataModel.username == "Log_Anh")
                    {
                        ViewData["display"] = "block";
                    }
                    return View();
                }
                else
                {
                    return RedirectToRoute(new { controller = "Home", action = "UnAutherize" });
                }
            }
        }
        public IActionResult _Bu_Checking()
        {
            return View();
        }
    }
}
