using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using NBAWeb.Models;

namespace NBAWeb.Controllers
{
    public class StatisticsController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7154/api");
        private readonly HttpClient _httpClient;

        public StatisticsController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }
        public IActionResult GetNumPlayersBySeason()
        {
            List<DTO_Statistics_NumPlayersBySeason> arenas = new List<DTO_Statistics_NumPlayersBySeason>();
            using (HttpResponseMessage response = _httpClient.GetAsync(baseAddress + "/NumPlayersBySeason").Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    arenas = JsonConvert.DeserializeObject<List<DTO_Statistics_NumPlayersBySeason>>(data);
                }
            }
            return View(arenas);
        }

        public IActionResult GetPlayerRankBySeason(int playerId)
        {
            List<DTO_Statistics_PlayerRankBySeason> arenas = new List<DTO_Statistics_PlayerRankBySeason>();
            using (HttpResponseMessage response = _httpClient.GetAsync(baseAddress + $"/Statistics/PlayerRankBySeason?playerId={playerId}").Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    arenas = JsonConvert.DeserializeObject<List<DTO_Statistics_PlayerRankBySeason>>(data);
                }
            }
            return View(arenas);
        }

        public IActionResult GetPlayersBySeason( int seasonId, int teamid)
        {
            DTO_Statistics_PlayersBySeason arenas = new DTO_Statistics_PlayersBySeason();
            using (HttpResponseMessage response = _httpClient.GetAsync(baseAddress + $"/Statistics/PlayersBySeason?seasonId={seasonId}&teamid={teamid}").Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    arenas = JsonConvert.DeserializeObject<DTO_Statistics_PlayersBySeason>(data);
                }
            }
            return View(arenas);
        }

        public IActionResult GetTop5RankedPlayerByPlayoffSeason()
        {
            List<DTO_Statistics_Top5RankedPlayerByPlayoffSeason> arenas = new List<DTO_Statistics_Top5RankedPlayerByPlayoffSeason>();
            using (HttpResponseMessage response = _httpClient.GetAsync(baseAddress + "/Top5RankedPlayerByPlayoffSeason").Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    arenas = JsonConvert.DeserializeObject<List<DTO_Statistics_Top5RankedPlayerByPlayoffSeason>>(data);
                }
            }
            return View(arenas);
        }

        public IActionResult GetTop5RankedPlayerByRegularSeason()
        {
            List<DTO_Statistics_Top5RankedPlayerByRegularSeason> arenas = new List<DTO_Statistics_Top5RankedPlayerByRegularSeason>();
            using (HttpResponseMessage response = _httpClient.GetAsync(baseAddress + "/Top5RankedPlayerByRegularSeason").Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    arenas = JsonConvert.DeserializeObject<List<DTO_Statistics_Top5RankedPlayerByRegularSeason>>(data);
                }
            }
            return View(arenas);
        }
    }
}
