using NBAWeb.Models;
 

namespace NBAWeb.Models
{
    public class DTO_StateDetails
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Flag { get; set; }
        public List<DTO_TeamSummary> Teams { get; set; }
        public List<DTO_ArenaSummary> Arenas { get; set; }
 
    }
}
