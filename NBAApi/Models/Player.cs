﻿using System.ComponentModel.DataAnnotations;

namespace NBAApi.Models
{
    public class Player
    {
        public string Id { get; set; }
        public string?  Name { get; set; }
        public DateTime? Birthdate { get; set; }
      
        public int? DraftYear { get; set; }
     
        public double? Height { get; set; }
        public double? Weight { get; set; }
        public string?  School { get; set; }
        public string?  Photo { get; set; }
        public string?  Biography { get; set; }
        public string? CountryId { get; set; }
        public string? PositionId { get; set; }


        public Country? Country { get; set; }
        public  Position? Position { get; set; }
        public  ICollection<Statistic?> Statistics { get; set; }
    }
}

