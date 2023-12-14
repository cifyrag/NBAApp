using Microsoft.AspNetCore.Mvc;
using NBAWeb.Models;
using Newtonsoft.Json;

namespace NBAWeb.Controllers
{
    public class DivisionsController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7154/api");
        private readonly HttpClient _httpClient;

        public DivisionsController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }

        public IActionResult GetDivisions()
        {
            DTO_Conference divisions = new DTO_Conference();
            using (HttpResponseMessage response = _httpClient.GetAsync(baseAddress + "/Divisions").Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    divisions = JsonConvert.DeserializeObject<DTO_Conference>(data);
                }
            }
            return View(divisions);
        }

        public IActionResult GetDivision(int id)
        {
            DTO_DivisionDetails division = new DTO_DivisionDetails();
            using (HttpResponseMessage response = _httpClient.GetAsync(baseAddress + $"/Divisions/{id}").Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    division = JsonConvert.DeserializeObject<DTO_DivisionDetails>(data);
                }
            }
            return View(division);
        }
    }
}
