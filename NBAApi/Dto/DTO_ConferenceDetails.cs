using NBAApi.Dto;

using NBAApi.Models;


namespace NBAApi.Dto
{
    public class DTO_ConferenceDetails
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? Logo { get; set; }
        public List<DTO_TeamSummary?> Teams { get; set; }


        public static DTO_ConferenceDetails? ToDTO_ConferenceDetails(Conference conference)
        {
            if (conference == null)
            {
                return null;
            }
            return new DTO_ConferenceDetails
            {
                Id = conference.Id,
                Name = conference.Name,
                Logo = conference.Logo,
                Teams =conference.Teams.Select(x => DTO_TeamSummary.ToDTO_TeamSummary(x)).ToList(),
            };
        }
    }
}
