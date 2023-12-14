using NBAApi.Models;

namespace NBAApi.Dto
{
    public class DTO_ConferenceSummary
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static DTO_ConferenceSummary? ToDTO_ConferenceSummary(Conference conference)
        {
            if (conference == null)
            {
                return null;
            }
            return new DTO_ConferenceSummary
            {
                Id = conference.Id,
                Name = conference.Name,
            };
        }
    }
}
