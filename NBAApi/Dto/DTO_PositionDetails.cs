using NBAApi.Dto;
using NBAApi.Models;

namespace NBAApi.Dto
{
    public class DTO_PositionDetails
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<DTO_PlayerSummary> Players { get; set; }

        public static DTO_PositionDetails? ToDTO_PositionDetails(Position position)
        {
            if (position == null)
            {
                return null;
            }
            return new DTO_PositionDetails
            {
                Id = position.Id,
                Name = position.Name,
                Description = position.Description,
                Players = position.Players.Select(x => DTO_PlayerSummary.ToDTO_PlayerSummary(x)).ToList(),
            };
        }
    }
}
