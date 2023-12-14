using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using NBAWeb.Models;

namespace NBAWeb.Controllers
{
    public class SeasonTypesController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7154/api");
        private readonly HttpClient _httpClient;

        public SeasonTypesController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }
        public IActionResult GetSeasonTypes()
        {
            DTO_SeasonTypes seasonTypes = new DTO_SeasonTypes();
            using (HttpResponseMessage response = _httpClient.GetAsync(baseAddress + "/SeasonTypes").Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    seasonTypes = JsonConvert.DeserializeObject<DTO_SeasonTypes>(data);
                }
            }
            return View(seasonTypes);
        }

        public IActionResult GetSeasonType(int id)
        {
            DTO_SeasonTypeDetails seasonTypes = new DTO_SeasonTypeDetails();
            using (HttpResponseMessage response = _httpClient.GetAsync(baseAddress + $"/SeasonTypes/{id}").Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    seasonTypes = JsonConvert.DeserializeObject<DTO_SeasonTypeDetails>(data);
                }
            }
            return View(seasonTypes);
        }
    }
}
