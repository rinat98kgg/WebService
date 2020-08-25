using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebService.WebClient.Models;

namespace WebClient.Controllers
{
    public class GendersController : Controller
    {
        // GET: Genders
        public ActionResult Index()
        {
            IEnumerable<GENDER> List;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("GENDERs").Result;
            List = response.Content.ReadAsAsync<IEnumerable<GENDER>>().Result;
            return View(List);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new GENDER());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("GENDERs/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<GENDER>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(GENDER gen)
        {
            if(gen.GENDER_ID == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("GENDERs", gen).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("GENDERs/" + gen.GENDER_ID, gen).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("GENDERs/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}