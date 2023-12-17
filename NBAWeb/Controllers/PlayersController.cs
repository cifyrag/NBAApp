using Microsoft.AspNetCore.Mvc;
using NBAWeb.Models;
using Newtonsoft.Json;

namespace NBAWeb.Controllers
{
    public class PlayersController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7154/api");
        private readonly HttpClient _httpClient;

        public PlayersController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }

        public IActionResult GetPlayers()
        {
            DTO_Players players = new DTO_Players();
            using (HttpResponseMessage response = _httpClient.GetAsync(baseAddress + "/Players").Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    players = JsonConvert.DeserializeObject<DTO_Players>(data);
                }
            }
            return View("GetPlayersPage", players);
           
        }

        public IActionResult GetPlayer(int id)
        {
            DTO_PlayerDetails players = new DTO_PlayerDetails();
            using (HttpResponseMessage response = _httpClient.GetAsync(baseAddress + $"/Players/{id}").Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    players = JsonConvert.DeserializeObject<DTO_PlayerDetails>(data);
                }
            }
            return View(players);
        }

        public IActionResult SearchPlayers(string q)
        {
            
            List<DTO_PlayerSummary> players = new List<DTO_PlayerSummary>();
            using (HttpResponseMessage response = _httpClient.GetAsync(baseAddress + $"/Players/Search?q={q}").Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    players = JsonConvert.DeserializeObject<List<DTO_PlayerSummary>>(data);
                }
            }
            return View("GetPlayersPage", DTO_Players.ToDTO_Players( players, players.Count));
        }

        public IActionResult GetPlayersPage(int page, int pagesize)
        {
            DTO_Players players = new DTO_Players();
            using (HttpResponseMessage response = _httpClient.GetAsync(baseAddress + $"/Players/Page?page={page}&pagesize={pagesize}").Result)
            
            {
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    players = JsonConvert.DeserializeObject<DTO_Players>(data);
                }
            }
            return View(players);
            
        }
    }
}
