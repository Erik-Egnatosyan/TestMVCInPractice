using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestMVCInPractice.Models;

namespace TestMVCInPractice.Controllers
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
            var languageData = _context.MultiLangauges.FirstOrDefault();
            if (languageData != null)
            {
                ViewBag.LanguageText = languageData.EnglishLang;
                return View(languageData); // Передача модели в представление
            }
            else
            {
                ViewBag.LanguageText = "No language data found.";
                return View();
            }
        }


        [HttpPost]
        public IActionResult ChangeLanguage(string language, int id)
        {
            var languageData = _context.MultiLangauges.FirstOrDefault(lang => lang.id == id);
            if (languageData != null)
            {
                switch (language)
                {
                    case "Armenian":
                        ViewBag.LanguageText = languageData.ArmenianLang;
                        break;
                    case "Russian":
                        ViewBag.LanguageText = languageData.RussioanLang;
                        break;
                    case "English":
                        ViewBag.LanguageText = languageData.EnglishLang;
                        break;
                    default:
                        ViewBag.LanguageText = "Invalid language.";
                        break;
                }
            }
            else
            {
                ViewBag.LanguageText = "No language data found.";
            }

            return Content(ViewBag.LanguageText);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}