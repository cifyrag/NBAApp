using NBAApi.Models;

namespace NBAApi.Dto
{
    public class DTO_SeasonTypeSummary
    {
        public string? Id { get; set; }
        public string? Name { get; set; }

        public static DTO_SeasonTypeSummary? ToDTO_SeasonTypeSummary(SeasonType seasonType)
        {
            if (seasonType == null)
            {
                return null;
            }
            return new DTO_SeasonTypeSummary
            {
                Id = seasonType.Id,
                Name = seasonType.Name,
            };
        }
    }
}
