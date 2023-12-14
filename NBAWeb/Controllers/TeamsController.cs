using Microsoft.AspNetCore.Mvc;
using NBAWeb.Models;
using Newtonsoft.Json;

namespace NBAWeb.Controllers
{
    public class TeamsController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7154/api");
        private readonly HttpClient _httpClient;

        public TeamsController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }
        public IActionResult GetTeams()
        {
            DTO_Teams teams = new DTO_Teams();
            using (HttpResponseMessage response = _httpClient.GetAsync(baseAddress + "/Teams").Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    teams = JsonConvert.DeserializeObject<DTO_Teams>(data);
                }
            }
            return View("GetTeamsPage", teams);
        }

        public IActionResult GetTeam(int id)
        {
            DTO_TeamDetails teams = new DTO_TeamDetails();
            using (HttpResponseMessage response = _httpClient.GetAsync(baseAddress + $"/Teams/{id}").Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    teams = JsonConvert.DeserializeObject<DTO_TeamDetails>(data);
                }
            }
            return View(teams);
        }

        public IActionResult SearchTeams(string q)
        {
            List<DTO_TeamSummary> teams = new List<DTO_TeamSummary>();
            using (HttpResponseMessage response = _httpClient.GetAsync(baseAddress + $"/Teams/Search?q={q}").Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    teams = JsonConvert.DeserializeObject<List<DTO_TeamSummary>>(data);
                }
            }
            return View("GetTeamsPage", DTO_Teams.ToDTO_Teams( teams));
        }

        public IActionResult GetTeamsPage(int page, int pagesize)
        {
            DTO_Teams teams = new DTO_Teams();
            using (HttpResponseMessage response = _httpClient.GetAsync(baseAddress + $"/Teams/Page?page={page}&pagesize={pagesize}").Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    teams = JsonConvert.DeserializeObject<DTO_Teams>(data);
                }
            }
            return View(teams);
        }
    }
}
