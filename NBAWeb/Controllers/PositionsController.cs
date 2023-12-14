using Microsoft.AspNetCore.Mvc;
using NBAWeb.Models;
using Newtonsoft.Json;

namespace NBAWeb.Controllers
{
    public class PositionsController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7154/api");
        private readonly HttpClient _httpClient;

        public PositionsController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }

        public IActionResult GetPositions()
        {
            DTO_Positions positions = new DTO_Positions();
            using (HttpResponseMessage response = _httpClient.GetAsync(baseAddress + "/Positions").Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    positions = JsonConvert.DeserializeObject<DTO_Positions>(data);
                }
            }
            return View(positions);
        }

        public IActionResult GetPosition(int id)
        {
            DTO_PositionDetails positions = new DTO_PositionDetails();
            using (HttpResponseMessage response = _httpClient.GetAsync(baseAddress + $"/Positions/{id}").Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    positions = JsonConvert.DeserializeObject<DTO_PositionDetails>(data);
                }
            }
            return View(positions);
        }
    }
}
