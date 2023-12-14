using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;
using NBAWeb.Models;

namespace NBAWeb.Controllers
{
    public class ArenasController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7154/api");
        private readonly HttpClient _httpClient;

        public ArenasController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }

        public IActionResult GetArenas()
        {
            DTO_Arenas arenas = new DTO_Arenas();
            using (HttpResponseMessage response = _httpClient.GetAsync(baseAddress + "/Arenas").Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    arenas = JsonConvert.DeserializeObject<DTO_Arenas>(data);
                }
            }
            return View("GetArenasPage", arenas);
        }

        public IActionResult GetArena( int id)
        {
            DTO_ArenaDetails arenas = new DTO_ArenaDetails();
            using (HttpResponseMessage response = _httpClient.GetAsync(baseAddress + $"/Arenas/{id}").Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    arenas = JsonConvert.DeserializeObject<DTO_ArenaDetails>(data);
                }
            }
            return View(arenas);
        }

        public IActionResult SearchArenas(string q)
        {
        
            List<DTO_ArenaSummary> arenas = new List<DTO_ArenaSummary>();
            using (HttpResponseMessage response = _httpClient.GetAsync(baseAddress + $"/Arenas/Search?q={q}").Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    arenas = JsonConvert.DeserializeObject<List<DTO_ArenaSummary>>(data);
                }
            }
            return View("GetArenasPage", DTO_Arenas.ToDTO_Arenas(arenas));
        }

        public IActionResult GetArenasPage(int page, int pagesize)
        {
            DTO_Arenas arenas = new DTO_Arenas();
            using (HttpResponseMessage response = _httpClient.GetAsync(baseAddress + $"/Arenas/Page?page={page}&pagesize={pagesize}").Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    arenas = JsonConvert.DeserializeObject<DTO_Arenas>(data);
                }
            }
            return View(arenas);
        }

    }
}
