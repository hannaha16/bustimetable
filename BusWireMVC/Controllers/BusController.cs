using System;
using System.Web.Mvc;
using BusWireMVC.Models;
using BusWireMVC.ViewModels;

namespace BusWireMVC.Controllers
{
    public class BusController : Controller
    {
        [HttpGet]
        public ActionResult Info(string postCode)
        {
            var info = GetInfo(postCode);
            return View(info);
        }
        
        [HttpGet]
        public PartialViewResult Results(string postCode)
        {
            var info = GetInfo(postCode);
            return PartialView("Results", info);
        }

        private BusInfoViewModel GetInfo(string postCode)
        {
            var info = new BusInfoViewModel(postCode);
            if (info.PostCode.Latitude == 0)
            {
                ModelState.AddModelError(string.Empty, "Valid UK postcodes only.");
            }
            info.Update();
            if (info.BusStops.Count == 0)
            {
                ModelState.AddModelError(string.Empty, "Couldn't find any bus stops near that postcode. Was it in London?");
            }
            return info;
        }
    }
}