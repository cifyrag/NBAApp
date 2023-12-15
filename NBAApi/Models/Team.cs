using System.ComponentModel.DataAnnotations;

namespace NBAApi.Models
{
    public class Team
    {
        public string Id { get; set; }
        public string?  Acronym { get; set; }
        public string?  Name { get; set; }

        public string?  City { get; set; }
        public string?  Logo { get; set; }
        public string?  History { get; set; }
        public string? ConferenceId { get; set; }
        public string? DivisionId { get; set; }
        public string? StateId { get; set; }




        public Conference? Conference { get; set; }
        public Division? Division { get; set; }
        public State? State { get; set; }
        public ICollection<Arena?> Arenas { get; set; }
        public ICollection<Statistic?> Statistics { get; set; }


    }
}
