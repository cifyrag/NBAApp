using NBAWeb.Models;

namespace NBAWeb.Models
{
    public class DTO_Statistics_PlayersBySeason
    {
        public string? Season { get; set; }
        public string? SeasonType { get; set; }
        public List<DTO_PlayerShort> Players { get; set; }

       
    }
}
