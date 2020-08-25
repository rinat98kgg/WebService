using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebService.WebClient.Models;

namespace WebClient.Controllers
{
    public class BanksController : Controller
    {
        // GET: Banks
        public ActionResult Index()
        {
            IEnumerable<BANKS> List;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("BANKS").Result;
            List = response.Content.ReadAsAsync<IEnumerable<BANKS>>().Result;
            return View(List);
        }
    }
}