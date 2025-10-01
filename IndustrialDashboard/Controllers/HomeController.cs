using System.Diagnostics;
using IndustrialDashboard.Models;
using Microsoft.AspNetCore.Mvc;

namespace IndustrialDashboard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Devices()
        {
            // For demo, pass 13 devices
            var devices = new List<string>();
            for (int i = 1; i <= 13; i++)
            {
                devices.Add($"Device {i}");
            }

            ViewBag.Devices = devices;
            return View();
        }

        public IActionResult Report()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
