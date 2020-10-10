
using CoinData;
using CoinJar.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CoinJar.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult CoinJar()
        {
            CoinJarViewModel model = new CoinJarViewModel();
            return View(model);
        }
        public async Task<ActionResult> AddCoin(int coinTypeID)
        {         
            CoinJarViewModel model = new CoinJarViewModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseUrl"]);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync($"api/JarAPI/GetAddCoinResult?coinTypeID={coinTypeID}");

                if (Res.IsSuccessStatusCode)
                {
                    var response = Res.Content.ReadAsStringAsync().Result;
                    model.TotalAmount = JsonConvert.DeserializeObject<APIResponse>(response).TotalAmount;
                    model.TotalVolume = JsonConvert.DeserializeObject<APIResponse>(response).TotalVolume;
                    model.OutputMessage = JsonConvert.DeserializeObject<APIResponse>(response).ResponseMesage;
                }
            }
            return View(model);
        }

        public async Task<ActionResult> GetTotalAmount()
        {
            CoinJarViewModel model = new CoinJarViewModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseUrl"]);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("api/JarAPI/GetTotalAmount");

                if (Res.IsSuccessStatusCode)
                {
                    var response = Res.Content.ReadAsStringAsync().Result;
                    model.TotalAmount = JsonConvert.DeserializeObject<APIResponse>(response).TotalAmount;
                    model.TotalVolume = JsonConvert.DeserializeObject<APIResponse>(response).TotalVolume;
                    model.OutputMessage = JsonConvert.DeserializeObject<APIResponse>(response).ResponseMesage;
                }
            }
            return View(model);
        }

        public async Task<ActionResult> Reset()
        {
            CoinJarViewModel model = new CoinJarViewModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseUrl"]);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("api/JarAPI/GetResetResult");

                if (Res.IsSuccessStatusCode)
                {
                    var response = Res.Content.ReadAsStringAsync().Result;
                    model.OutputMessage = JsonConvert.DeserializeObject<APIResponse>(response).ResponseMesage;
                }
            }
            return View(model);
        }
    }
}