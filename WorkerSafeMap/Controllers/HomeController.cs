using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using WorkSafeMap.Models;
using System.Data.Entity;
using Microsoft.Azure; // Namespace for CloudConfigurationManager
using Microsoft.WindowsAzure.Storage; // Namespace for CloudStorageAccount
using Microsoft.WindowsAzure.Storage.Table; // Namespace for Table storage types
using System.Data;
using WorkSafeMap.Controllers.shared;

namespace WorkSafeMap.Controllers
{
    
    public class HomeController : Controller
    {
        private IncidentEntity.IncidentEntityDBContext db = new IncidentEntity.IncidentEntityDBContext();
        
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
            string searchURL = "http://dev.virtualearth.net/REST/v1/Locations/{locationQuery}?includeNeighborhood={includeNeighborhood}&maxResults={maxResults}&include={includeValue}&key=" + BINGMAPS_KEY;

            CloudTable table = DataAccess.GetDataTable("incidents");

            TableQuery<IncidentEntity> query = new TableQuery<IncidentEntity>();

            var items = table.ExecuteQuery(query).ToList();
            //db.IncidentEntities.
            //db.SaveChanges();

            return View(items);
        }

    }
}