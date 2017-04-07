using System.Web.Mvc;
using BusWireMVC.Models;
using BusWireMVC.ViewModels;

namespace BusWireMVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About BusBoard";

            return View();
        }
    }
}