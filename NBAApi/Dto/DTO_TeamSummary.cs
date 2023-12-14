using NBAApi.Dto;
using NBAApi.Models;

namespace NBAApi.Dto
{
    public class DTO_TeamSummary
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

        public static DTO_TeamSummary? ToDTO_TeamSummary(Team team)
        {
            if (team == null)
            {
                return null;
            }
            return new DTO_TeamSummary
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


            };
        }
    }
}
