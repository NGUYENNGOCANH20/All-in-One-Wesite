using All_in_One_Wesite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace All_in_One_Wesite.Controllers
{
    public class LoginController : Microsoft.AspNetCore.Mvc.Controller
    {
        [HttpPost]
        public IActionResult Login(string username,string password)
        {
            try
            {
                DataModel.username = username;
                DataModel.password = password;
                var connection = DataModel.connection;
                connection.Open();
                SqlCommand command = new SqlCommand($"Select * FROM [User name] WHERE Username LIKE '{username}' AND Password LIKE '{password}';", connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DataModel.Paslogin = true;
                        connection.Close();
                        return RedirectToRoute(new { controller = "Home", action = "Home" });

                    }
                    else
                    {
                        DataModel.Paslogin = false;
                        connection.Close();
                        return View();
                    }
                }
            }
            catch (Exception)
            {
                return RedirectToRoute(new { controller = "Home", action = "Error" });
            }
            
        }
        [HttpGet]
        public IActionResult Login()
        {
            DataModel.username = "";
            DataModel.password = "";
            return View();
        }
    }
}
