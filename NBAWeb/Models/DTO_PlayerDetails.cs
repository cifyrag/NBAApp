 
using NBAWeb.Models;

namespace NBAWeb.Models
{
    public class DTO_PlayerDetails
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public DateTime? Birthdate { get; set; }
        public string? CountryId { get; set; }
        public string? CountryName { get; set; }
        public int? DraftYear { get; set; }
        public string? PositionId { get; set; }
        public string? PositionName { get; set; }
        public string? Height { get; set; }
        public string? Weight { get; set; }
        public string? School { get; set; }
        public string? Photo { get; set; }
        public string? Biography { get; set; }
        public List<DTO_SeasonSummary> Seasons { get; set; }
        public List<DTO_TeamSummary> Teams { get; set; }

 
    }
}
