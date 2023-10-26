using Microsoft.AspNetCore.Mvc;
using QIMSchoolPro.Thesis.WebUI.Models;
using System.Diagnostics;

namespace QIMSchoolPro.Thesis.WebUI.Controllers
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

        
    }
}