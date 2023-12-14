using NBAApi.Models;

namespace NBAApi.Dto
{
    public class DTO_Statistics_PlayersBySeason
    {
        public string Season { get; set; }
        public string SeasonType { get; set; }
        public List<DTO_PlayerShort> Players { get; set; }

        public static DTO_Statistics_PlayersBySeason? ToDTO_Statistics_PlayersBySeason(Statistic statistic, List<Player> players)
        {
            if (statistic == null)
            {
                return null;
            }
            return new DTO_Statistics_PlayersBySeason
            {
                Season = statistic.Year.Season,
                SeasonType = statistic.SeasonType.Name,
                Players = players.Select(x => DTO_PlayerShort.ToDTO_PlayerShort(x)).ToList(),
            };
        }
    }
}
