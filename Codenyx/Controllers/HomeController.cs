using Codenyx.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Codenyx.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LanguagesContext _context;

        public HomeController(ILogger<HomeController> logger, LanguagesContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            // Get the data from the database
            var languages = _context.MultiLanguages.FirstOrDefault();

            // Return the view
            return View(languages);
        }

        [HttpPost]
        public IActionResult ChangeLanguage(string language)
        {
            // Get the text from the database
            var text = _context.GetText(language);

            // Return the text as JSON
            return Json(text);
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