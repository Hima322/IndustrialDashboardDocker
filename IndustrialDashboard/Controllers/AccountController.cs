using Microsoft.AspNetCore.Mvc;

namespace YourApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (!string.IsNullOrEmpty(username) && password == "1234")
            {
                TempData["User"] = username; // keep username for next request
                return RedirectToAction("Camera"); // go to camera page
            }

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
