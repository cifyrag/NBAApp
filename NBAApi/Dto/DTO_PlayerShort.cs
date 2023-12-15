using NBAApi.Models;

namespace NBAApi.Dto
{
    public class DTO_PlayerShort
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public static DTO_PlayerShort? ToDTO_PlayerShort(Player player)
        {
            if (player == null)
            {
                return null;
            }
            return new DTO_PlayerShort
            {
                Id = player.Id,
                Name = player.Name,

            };
        }
    }
}
