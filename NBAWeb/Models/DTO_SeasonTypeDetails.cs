using NBAWeb.Models;

namespace NBAWeb.Models
{
    public class DTO_SeasonTypeDetails
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public List<DTO_SeasonSummary> Seasons { get; set; }
 
    }
}
