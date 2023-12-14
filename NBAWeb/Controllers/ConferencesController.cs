using Microsoft.AspNetCore.Mvc;
using NBAWeb.Models;
using Newtonsoft.Json;
namespace NBAWeb.Controllers
{
    public class ConferencesController: Controller
    {
        Uri baseAddress = new Uri("https://localhost:7154/api");
        private readonly HttpClient _httpClient;

        public ConferencesController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }

        public IActionResult GetConferences()
        {
            DTO_Conference conferences = new DTO_Conference();
            using (HttpResponseMessage response = _httpClient.GetAsync(baseAddress + "/Conferences").Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    conferences = JsonConvert.DeserializeObject<DTO_Conference>(data);
                }
            }
            return View(conferences);
        }

        public IActionResult GetConference(int id)
        {
            DTO_ConferenceDetails conference = new DTO_ConferenceDetails();
            using (HttpResponseMessage response = _httpClient.GetAsync(baseAddress + $"/Conferences/{id}").Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    conference = JsonConvert.DeserializeObject<DTO_ConferenceDetails>(data);
                }
            }
            return View(conference);
        }
    }
}
