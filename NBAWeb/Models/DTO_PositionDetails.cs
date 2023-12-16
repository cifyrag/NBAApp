 
using NBAWeb.Models;

namespace NBAWeb.Models
{
    public class DTO_PositionDetails
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<DTO_PlayerSummary> Players { get; set; }
 
    }
}
