using NBAApi.Dto;
using NBAApi.Models;
using System.Numerics;

namespace NBAApi.Dto
{
    public class DTO_SeasonDetails
    {
        public string? Id { get; set; }
        public string? Season { get; set; }
        public List<DTO_TeamSummary> Teams { get; set; }
        public List<DTO_PlayerSummary> Players { get; set; }

        public static DTO_SeasonDetails? ToDTO_SeasonDetails(Year season)
        {
            if (season == null)
            {
                return null;
            }
            return new DTO_SeasonDetails
            {
                Id = season.Id,
                Season = season.Season,
                Teams = season.Statistics.Where(e => e.YearId == season.Id).Select(x => DTO_TeamSummary.ToDTO_TeamSummary(x.Team)).ToList(),
                Players = season.Statistics.Where(e => e.YearId == season.Id).Select(x => DTO_PlayerSummary.ToDTO_PlayerSummary(x.Player)).ToList(),
            };
        }
    }
}
