using NBAApi.Models;

namespace NBAApi.Dto
{
    public class DTO_PlayerRank
    {
        public int? Rank { get; set; }
        public string? PlayerId { get; set; }
        public string? PlayerName { get; set; }

        public static DTO_PlayerRank? ToDTO_PlayerRank(Player player)
        {
            if (player == null)
            {
                return null;
            }
            return new DTO_PlayerRank
            {
                Rank = player.Statistics.Select(x => x.Rank).LastOrDefault(),
                PlayerId = player.Id,
                PlayerName = player.Name

            };
        }
    }


}
