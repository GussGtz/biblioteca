using System.Diagnostics;
using BibliotecaSánchezLobatoGael83.Models;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaSánchezLobatoGael83.Controllers
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult NotFound()
        {
            Response.StatusCode = 404;  // Establece el código de estado HTTP a 404
            return View();  // Devuelve la vista "NotFound.cshtml"
        }
    }
}
