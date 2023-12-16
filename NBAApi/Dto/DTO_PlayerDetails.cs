using NBAApi.Dto;
using NBAApi.Models;

namespace NBAApi.Dto
{
    public class DTO_PlayerDetails
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public DateTime? Birthdate { get; set; }
        public string? CountryId { get; set; }
        public string? CountryName { get; set; }
        public int? DraftYear { get; set; }
        public string? PositionId { get; set; }
        public string? PositionName { get; set; }
        public string? Height { get; set; }
        public string? Weight { get; set; }
        public string? School { get; set; }
        public string? Photo { get; set; }
        public string? Biography { get; set; }
        public List<DTO_SeasonSummary> Seasons { get; set; }
        public List<DTO_TeamSummary> Teams { get; set; }

        public static DTO_PlayerDetails? ToDTO_PlayerDetails(Player player)
        {
            if (player == null)
            {
                return null;
            }
            return new DTO_PlayerDetails
            {
                Id = player.Id,
                Name = player.Name,
                Birthdate = player.Birthdate,
                CountryId = player.CountryId,
                CountryName = player.Country.Name,
                DraftYear = player.DraftYear,
                PositionId = player.Position.Id,
                PositionName =  player.Position.Name,
                Height = player.Height.ToString(),
                Weight = player.Weight.ToString(),
                School = player.School,
                Photo = player.Photo,
                Biography = player.Biography,

                Teams = player.Statistics.Select(x => DTO_TeamSummary.ToDTO_TeamSummary(x.Team)).ToList(),
                
                Seasons = player.Statistics.Select(x => DTO_SeasonSummary.ToDTO_SeasonSummary(x.Year)).ToList(),
                

            };
        }
    }
}
