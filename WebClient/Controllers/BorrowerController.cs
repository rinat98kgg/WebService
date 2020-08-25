using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebService.WebClient.Models;

namespace WebClient.Controllers
{
    public class BorrowerController : Controller
    {
        // GET: Borrower
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SearchBorrowInfo(int lico_id)
        {
            try
            {
                IEnumerable<BORROWER> List;
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("BORROWER/" + lico_id.ToString()).Result;
                List = response.Content.ReadAsAsync<IEnumerable<BORROWER>>().Result;
                ViewBag.NotValue = "";
                if (List.Count() == 0)
                {
                    ViewBag.NotValue = "Нету заемщика с таким ID!";
                }
                return View(List);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}