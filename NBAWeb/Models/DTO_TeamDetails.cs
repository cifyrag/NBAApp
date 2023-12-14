
using NBAWeb.Models;

namespace NBAWeb.Models
{
    public class DTO_TeamDetails
    {
        public int Id { get; set; }
        public string Acronym { get; set; }
        public string Name { get; set; }
        public int ConferenceId { get; set; }
        public string ConferenceName { get; set; }
        public int DivisionId { get; set; }
        public string DivisionName { get; set; }
        public int StateId { get; set; }
        public string StateName { get; set; }
        public string City { get; set; }
        public string Logo { get; set; }
        public string History { get; set; }
        public List<DTO_SeasonSummary> Seasons { get; set; }
        public List<DTO_PlayerSummary> Players { get; set; }

        
    }
}
