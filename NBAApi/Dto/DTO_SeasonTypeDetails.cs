using NBAApi.Models;

namespace NBAApi.Dto
{
    public class DTO_SeasonTypeDetails
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public List<DTO_SeasonSummary> Seasons { get; set; }

        public static DTO_SeasonTypeDetails? ToDTO_SeasonTypeDetails(SeasonType seasonType)
        {
            if (seasonType == null)
            {
                return null;
            }
            return new DTO_SeasonTypeDetails
            {
                Id = seasonType.Id,
                Name = seasonType.Name,
                Seasons = seasonType.Statistics.Select(x => DTO_SeasonSummary.ToDTO_SeasonSummary(x.Year)).ToList(),
            };
        }
    }
}
