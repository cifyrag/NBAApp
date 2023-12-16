 
using NBAWeb.Models;
using System.Numerics;

namespace NBAWeb.Models
{
    public class DTO_SeasonDetails
    {
        public string? Id { get; set; }
        public string? Season { get; set; }
        public List<DTO_TeamSummary> Teams { get; set; }
        public List<DTO_PlayerSummary> Players { get; set; }

 
    }
}
