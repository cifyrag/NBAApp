using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using NBAWeb.Models;

namespace NBAWeb.Controllers
{
    public class SearchController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7154/api");
        private readonly HttpClient _httpClient;

        public SearchController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }

        public IActionResult GetSearchsPage( string q, int page, int pagesize)
        {
            DTO_Search search = new DTO_Search();
            using (HttpResponseMessage response = _httpClient.GetAsync(baseAddress + $"/Search?q={q}&page={page}&pagesize={pagesize}").Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    search = JsonConvert.DeserializeObject<DTO_Search>(data);
                }
            }
            return View(search);
        }
    }
}
