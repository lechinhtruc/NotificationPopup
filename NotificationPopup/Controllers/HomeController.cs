using Microsoft.AspNetCore.Mvc;
using NotificationPopup.Models;
using System.Diagnostics;

namespace NotificationPopup.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {
            //_logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateNotify()
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