using NBAApi.Dto;
using NBAApi.Models;

namespace NBAApi.Dto
{
    public class DTO_PlayerSummary
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public string CountryId { get; set; }
        public string CountryName { get; set; }
        public int DraftYear { get; set; }
        public string PositionId { get; set; }
        public string PositionName { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string School { get; set; }
        public string Photo { get; set; }
        public string Biography { get; set; }

        public static DTO_PlayerSummary? ToDTO_PlayerSummary(Player player)
        {
            if (player == null)
            {
                return null;
            }
            return new DTO_PlayerSummary
            {
                Id = player.Id,
                Name = player.Name,
                Birthdate = player.Birthdate,
                CountryId = player.PlayerCountryId.ToString(),
                CountryName = player.Country.Name,
                DraftYear = player.DraftYear,
                PositionId = player.PlayerPositionId.ToString(),
                PositionName = player.Position.Name,
                Height = player.Height.ToString(),
                Weight = player.Weight.ToString(),  
                School = player.School,
                Photo = player.Photo,
                Biography = player.Biography,

            };
        }
    }
}
