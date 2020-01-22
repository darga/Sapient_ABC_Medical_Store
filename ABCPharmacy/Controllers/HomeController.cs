using ABCPharmacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ABCPharmacy.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<Medicine> medicines = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64189/api/");
                var responseTask = client.GetAsync("medicalstore");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Medicine>>();
                    readTask.Wait();
                    medicines = readTask.Result;
                }
                else //web api sent error response 
                {
                    medicines = Enumerable.Empty<Medicine>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(medicines);
        }
    }
}
