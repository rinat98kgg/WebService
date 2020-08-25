using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebService.WebClient.Models;

namespace WebClient.Controllers
{
    public class FizlicoesController : Controller
    {
        // GET: Fizlicoes
        public ActionResult Index()
        {
            IEnumerable<FIZLICO> List;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("FIZLICOes").Result;
            List = response.Content.ReadAsAsync<IEnumerable<FIZLICO>>().Result;
            return View(List);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new FIZLICO());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("FIZLICOes/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<FIZLICO>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(FIZLICO fiz)
        {
            if (fiz.FIZLICO_ID == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("FIZLICOes", fiz).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("FIZLICOes/" + fiz.FIZLICO_ID, fiz).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("FIZLICOes/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}