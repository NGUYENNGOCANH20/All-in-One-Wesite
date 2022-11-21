using All_in_One_Wesite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace All_in_One_Wesite.Controllers
{
    public class WacoalController : Microsoft.AspNetCore.Mvc.Controller
    {
        public IActionResult Wacoal()
        {
            switch(DataModel.Paslogin)
            {
                case true:
                    {
                        if (DataModel.username == "BU_Team" || DataModel.username == "Log_Anh" || DataModel.username == "Plan_Team")
                        {
                            return View();
                        }
                        else
                        {
                            return RedirectToRoute(new { controller = "Home", action = "UnAutherize" });
                        }
                    }
                case false:
                    {
                        return RedirectToRoute(new { controller = "Home", action = "UnAutherize" });
                    }
            }
        }
        public IActionResult H_Wacoal()
        {
            switch (DataModel.Paslogin)
            {
                case true:
                    {
                        if (DataModel.username == "BU_Team" || DataModel.username == "Log_Anh" || DataModel.username == "Plan_Team")
                        {
                            return View();
                        }
                        else
                        {
                            return RedirectToRoute(new { controller = "Home", action = "UnAutherize" });
                        }
                    }
                case false:
                    {
                        return RedirectToRoute(new { controller = "Home", action = "UnAutherize" });
                    }
            }
        }
        public IActionResult PKL_Wacoal()
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
        public IActionResult Plan_Wacoal()
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
