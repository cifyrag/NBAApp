using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using NBAWeb.Models;

namespace NBAWeb.Controllers
{
    public class SeasonsController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7154/api");
        private readonly HttpClient _httpClient;

        public SeasonsController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }
        public IActionResult GetSeasons()
        {
            DTO_Seasons seasons = new DTO_Seasons();
            using (HttpResponseMessage response = _httpClient.GetAsync(baseAddress + "/Seasons").Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    seasons = JsonConvert.DeserializeObject<DTO_Seasons>(data);
                }
            }
            return View("GetSeasonPage", seasons);
        }

        public IActionResult GetSeason(int id)
        {
            DTO_SeasonDetails seasons = new DTO_SeasonDetails();
            using (HttpResponseMessage response = _httpClient.GetAsync(baseAddress + $"/Seasons/{id}").Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    seasons = JsonConvert.DeserializeObject<DTO_SeasonDetails>(data);
                }
            }
            return View(seasons);
        }

        public IActionResult SearchSeason(string q)
        {
            List<DTO_SeasonSummary> seasons = new List<DTO_SeasonSummary>();
            using (HttpResponseMessage response = _httpClient.GetAsync(baseAddress + $"/Seasons/Search?q={q}").Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    seasons = JsonConvert.DeserializeObject<List<DTO_SeasonSummary>>(data);
                }
            }
            return View("GetSeasonPage", DTO_Seasons.ToDTO_Seasons( seasons));
        }

        public IActionResult GetSeasonPage(int page, int pagesize)
        {
            DTO_Seasons seasons = new DTO_Seasons();
            using (HttpResponseMessage response = _httpClient.GetAsync(baseAddress + $"/Seasons/Page?page={page}&pagesize={pagesize}").Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    seasons = JsonConvert.DeserializeObject<DTO_Seasons>(data);
                }
            }
            return View(seasons);
        }
    }
}
