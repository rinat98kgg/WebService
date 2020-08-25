using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebService.WebClient.Models;

namespace WebClient.Controllers
{
    public class LocationsController : Controller
    {
        // GET: Locations
        public ActionResult Index()
        {
            IEnumerable<LOCATIONS> List;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("LOCATIONS").Result;
            List = response.Content.ReadAsAsync<IEnumerable<LOCATIONS>>().Result;
            return View(List);
        }
    }
}