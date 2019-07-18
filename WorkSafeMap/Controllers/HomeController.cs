using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace WorkSafeMap.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string BINGMAPS_KEY = ConfigurationManager.AppSettings["BINGMAPS_KEY"];
            ViewBag.BingMapsKey = BINGMAPS_KEY;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Map(string searchBox)
        {
      
            ViewBag.Message = searchBox;
            string BINGMAPS_KEY = ConfigurationManager.AppSettings["BINGMAPS_KEY"];
            ViewBag.BingMapsKey = BINGMAPS_KEY;
            string searchURL = "http://dev.virtualearth.net/REST/v1/Locations/{locationQuery}?includeNeighborhood={includeNeighborhood}&maxResults={maxResults}&include={includeValue}&key="+ BINGMAPS_KEY;


            return View();
        }

    }
}