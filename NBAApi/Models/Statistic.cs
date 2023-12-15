using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace NBAApi.Models
{
    public class Statistic
    {
        public string Id { get; set; }
        public int? Rank { get; set; }
        public int? GamesPlayed { get; set; }
        public int? MinutesPlayed { get; set; }
        public int? FGMade { get; set; }
        public int? FGAttempts { get; set; }
        public double? FGPercentage { get; set; }
        public int? ThreePtFGMade { get; set; }
        public int? ThreePtFGAttempts { get; set; }
        public double? ThreePtFGPercentage { get; set; }
        public int? FTMade { get; set; }
        public int? FTAttempts { get; set; }
        public double? FTPercentage { get; set; }
        public int? OffensiveRebounds { get; set; }
        public int? DefensiveRebounds { get; set; }
        public int? Rebounds { get; set; }
        public int? Assists { get; set; }
        public int? Steals { get; set; }
        public int? Blocks { get; set; }
        public int? Turnovers { get; set; }
        public int? PersonalFouls { get; set; }
        public int? PointScored { get; set; }
        public double? Efficiency { get; set; }
        public double? AST_TOV { get; set; }
        public double? STL_TOV { get; set; }

        public string? PlayerId { get; set; }
        public string? SeasonTypeId { get; set; }
        public string? TeamId { get; set; }
        public string? YearId { get; set; }




        public Player Player { get; set; }
        public SeasonType SeasonType { get; set; }
        public Team Team { get; set; }
        public Year Year { get; set; }
    }
}
