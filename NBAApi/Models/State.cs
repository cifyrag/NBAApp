using System.ComponentModel.DataAnnotations;

namespace NBAApi.Models
{
    public class State
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? Flag { get; set; }

        public ICollection<Arena> Arenas { get; set; }
        public ICollection<Team> Teams { get; set; }
    }
}
