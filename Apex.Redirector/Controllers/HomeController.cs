using Apex.Redirector.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Apex.Redirector.Controllers
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
            switch (this.Request.Host.Host.ToLower())
            {
                case "moonrise.net":
                    return RedirectPermanent("https://www.moonrise.net");
                case "cosmoswps.com":
                    return RedirectPermanent("https://www.cosmoswps.com");

            }
            return NotFound(404.100);
        }

        public IActionResult Privacy()
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