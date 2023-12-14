using NBAApi.Models;
using NBAApi.Dto;

namespace NBAApi.Dto
{
    public class DTO_TeamDetails
    {
        public int Id { get; set; }
        public string Acronym { get; set; }
        public string Name { get; set; }
        public int ConferenceId { get; set; }
        public string ConferenceName { get; set; }
        public int DivisionId { get; set; }
        public string DivisionName { get; set; }
        public string StateId { get; set; }
        public string StateName { get; set; }
        public string City { get; set; }
        public string Logo { get; set; }
        public string History { get; set; }
        public List<DTO_SeasonSummary> Seasons { get; set; }
        public List<DTO_PlayerSummary> Players { get; set; }

        public static DTO_TeamDetails? ToDTO_TeamDetails(Team team)
        {
            if (team == null)
            {
                return null;
            }
            return new DTO_TeamDetails
            {
                Id = team.Id,
                Acronym = team.Acronym,
                Name = team.Name,
                ConferenceId = team.TeamConferenceId,
                ConferenceName = team.Conference.Name,
                DivisionId = team.TeamDivisionId,
                DivisionName = team.Division.Name,
                StateId = team.State.Id,
                StateName = team.State.Name,
                City = team.City,
                Logo = team.Logo,
                History = team.History,
                Players = team.Statistics.Select(x => DTO_PlayerSummary.ToDTO_PlayerSummary(x.Player)).ToList(),
                Seasons = team.Statistics.Select(x => DTO_SeasonSummary.ToDTO_SeasonSummary(x.Year)).ToList(),

            };
        }
    }
}
