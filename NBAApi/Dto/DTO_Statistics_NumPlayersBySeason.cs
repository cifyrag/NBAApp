using NBAApi.Models;

namespace NBAApi.Dto
{
    public class DTO_Statistics_NumPlayersBySeason
    {
        public string? Season { get; set; }
        public string? SeasonType { get; set; }
        public int? Players { get; set; }

        public static DTO_Statistics_NumPlayersBySeason? ToDTO_Statistics_NumPlayersBySeason(KeyValuePair<string?, int> season)
        {
            if (season.Key == null)
            {
                return null;
            }
            string?[] key = season.Key.Split(' ');
            return new DTO_Statistics_NumPlayersBySeason
            {
                
                Season = key[0],
                SeasonType = key[1],
                Players = season.Value,

            };
        }
    }
}
