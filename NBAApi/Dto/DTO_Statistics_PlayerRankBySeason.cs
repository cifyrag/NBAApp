using NBAApi.Models;

namespace NBAApi.Dto
{
    public class DTO_Statistics_PlayerRankBySeason
    {
        public string? Season { get; set; }
        public string? SeasonType { get; set; }
        public int? Rank { get; set; }
        public static DTO_Statistics_PlayerRankBySeason? ToDTO_Statistics_PlayerRankBySeason(Statistic statistic)
        {
            if (statistic == null)
            {
                return null;
            }
            return new DTO_Statistics_PlayerRankBySeason
            {
                Season = statistic.Year.Season,
                SeasonType = statistic.SeasonType.Name,
                Rank = statistic.Rank,
                

            };
        }
    }
}
