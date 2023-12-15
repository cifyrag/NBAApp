using NBAApi.Dto;
using NBAApi.Models;

namespace NBAApi.Dto
{
    public class DTO_SeasonSummary
    {
        public string? Id { get; set; }
        public string? Season { get; set; }

        public static DTO_SeasonSummary? ToDTO_SeasonSummary(Year season)
        {
            if (season == null)
            {
                return null;
            }
            return new DTO_SeasonSummary
            {
                Id = season.Id,
                Season = season.Season,

            };
        }
    }
}
