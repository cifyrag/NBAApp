using NBAWeb.Models;


namespace NBAWeb.Models
{
    public class DTO_TeamSummary
    {
        public int Id { get; set; }
        public string Acronym { get; set; }
        public string Name { get; set; }
        public int ConferenceId { get; set; }
        public string ConferenceName { get; set; }
        public int DivisionId { get; set; }
        public string DivisionName { get; set; }
        public string StateId { get; set; }
        public string StateName { get; set; }
        public string City { get; set; }
        public string Logo { get; set; }
        public string History { get; set; }

        
    }
}
