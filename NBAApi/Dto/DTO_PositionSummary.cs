using NBAApi.Models;

namespace NBAApi.Dto
{
    public class DTO_PositionSummary
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public static DTO_PositionSummary? ToDTO_PositionSummary(Position position)
        {
            if (position == null)
            {
                return null;
            }
            return new DTO_PositionSummary
            {
                Id = position.Id,
                Name = position.Name,
                Description = position.Description,
            };
        }
    }
}
