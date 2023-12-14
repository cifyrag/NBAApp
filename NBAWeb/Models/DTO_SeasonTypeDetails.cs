

namespace NBAWeb.Models
{
    public class DTO_SeasonTypeDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<DTO_SeasonSummary> Seasons { get; set; }

        
    }
}
