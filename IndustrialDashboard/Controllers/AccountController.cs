using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace YourApp.Controllers
{
    public class AccountController : Controller
    {
        // Dictionary to store username and password
        private static readonly Dictionary<string, string> users = new Dictionary<string, string>
        {
            { "Admin", "1234" },
            { "Production", "1234" },
            { "Maintance", "1234" },
            { "Developer", "=1234" }
        };

        public IActionResult Login()
        {
            ViewBag.Users = users.Keys; 
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (users.ContainsKey(username) && users[username] == password)
            {
                TempData["User"] = username;
                return RedirectToAction("Index","Home");
            }

            ViewBag.Users = users.Keys;
            ViewBag.Message = "Invalid Login ID or Password!";
            return View();
        }

        public IActionResult Camera()
        {
            ViewBag.User = TempData["User"];
            return View();
        }
    }
}
