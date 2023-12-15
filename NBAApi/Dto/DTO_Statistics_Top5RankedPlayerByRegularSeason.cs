using NBAApi.Models;

namespace NBAApi.Dto
{
    public class DTO_Statistics_Top5RankedPlayerByRegularSeason
    {
        public string? Season { get; set; }
        public List<DTO_PlayerRank> Players { get; set; }

        public static DTO_Statistics_Top5RankedPlayerByRegularSeason? ToDTO_Statistics_Top5RankedPlayerByRegularSeason(KeyValuePair<string?, List<Statistic>> season)
        {
            if (season.Key==null)
            {
                return null;
            }
            return new DTO_Statistics_Top5RankedPlayerByRegularSeason
            {
                Season = season.Key,
                Players = season.Value
                .OrderByDescending(x => x.Rank)
                .Take(5)
                .Select(x => DTO_PlayerRank.ToDTO_PlayerRank(x.Player)).ToList(),
            };
        }
    }
}
