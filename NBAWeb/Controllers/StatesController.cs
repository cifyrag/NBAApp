using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using NBAWeb.Models;

namespace NBAWeb.Controllers
{
    public class StatesController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7154/api");
        private readonly HttpClient _httpClient;

        public StatesController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }
        public IActionResult GetStates()
        {
            DTO_States states = new DTO_States();
            using (HttpResponseMessage response = _httpClient.GetAsync(baseAddress + "/States").Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    states = JsonConvert.DeserializeObject<DTO_States>(data);
                }
            }
            return View("GetStatesPage", states);
        }

        public IActionResult GetState(int id)
        {
            DTO_StateDetails states = new DTO_StateDetails();
            using (HttpResponseMessage response = _httpClient.GetAsync(baseAddress + $"/States/{id}").Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    states = JsonConvert.DeserializeObject<DTO_StateDetails>(data);
                }
            }
            return View(states);
        }

        public IActionResult SearchStates(string q)
        {
            List<DTO_StateSummary> states = new List<DTO_StateSummary>();
            using (HttpResponseMessage response = _httpClient.GetAsync(baseAddress + $"/States/Search?q={q}").Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    states = JsonConvert.DeserializeObject<List<DTO_StateSummary>>(data);
                }
            }
            return View("GetStatesPage",DTO_States.ToDTO_States( states));
        }

        public IActionResult GetStatesPage(int page, int pagesize)
        {
            DTO_States states = new DTO_States();
            using (HttpResponseMessage response = _httpClient.GetAsync(baseAddress + $"/States/Page?page={page}&pagesize={pagesize}").Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    states = JsonConvert.DeserializeObject<DTO_States>(data);
                }
            }
            return View(states);
        }
    }
    
}
