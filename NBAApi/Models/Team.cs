﻿namespace NBAApi.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Acronym { get; set; }
        public string Name { get; set; }
        public int TeamConferenceId { get; set; }
        public int TeamDivisionId { get; set; }

        public int TeamStateId { get; set; }
        public string City { get; set; }
        public string Logo { get; set; }
        public string History { get; set; }

        public Conference Conference { get; set; }
        public Division Division { get; set; }
        public State State { get; set; }
        public ICollection<Arena> Arenas { get; set; }
        public ICollection<Statistic> Statistics { get; set; }


    }
}
