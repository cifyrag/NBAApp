using NBAWeb.Models;


namespace NBAWeb.Models
{
    public class DTO_ArenaSummary
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StateId { get; set; }
        public string StateName { get; set; }
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string TeamAcronym { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public int Opened { get; set; }
        public string Photo { get; set; }

        
    }
}
