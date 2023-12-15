using System.ComponentModel.DataAnnotations;

namespace NBAApi.Models
{
    public class Conference
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? Logo { get; set; }
        
        public List<Team> Teams { get; set; }
    }
}
