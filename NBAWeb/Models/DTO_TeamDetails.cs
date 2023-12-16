using NBAWeb.Models;
 

namespace NBAWeb.Models
{
    public class DTO_TeamDetails
    {
        public string? Id { get; set; }
        public string? Acronym { get; set; }
        public string? Name { get; set; }
        public string? ConferenceId { get; set; }
        public string? ConferenceName { get; set; }
        public string? DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public string? StateId { get; set; }
        public string? StateName { get; set; }
        public string? City { get; set; }
        public string? Logo { get; set; }
        public string? History { get; set; }
        public List<DTO_SeasonSummary> Seasons { get; set; }
        public List<DTO_PlayerSummary> Players { get; set; }

         
    }
}
