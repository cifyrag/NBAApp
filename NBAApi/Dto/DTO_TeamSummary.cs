using NBAApi.Dto;
using NBAApi.Models;

namespace NBAApi.Dto
{
    public class DTO_TeamSummary
    {
        public string? Id { get; set; }
        public string? Acronym { get; set; }
        public string? Name { get; set; }
        public string? ConferenceId { get; set; }
        public string? ConferenceName { get; set; }
        public string? DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public string? StateId { get; set; }
        public string? StateName { get; set; }
        public string? City { get; set; }
        public string? Logo { get; set; }
        public string? History { get; set; }

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
                ConferenceId =!( team.Conference == null )? team.Conference.Id: null,
                ConferenceName = !(team.Conference == null) ? team.Conference.Name : null,
                DivisionId = !(team.Division == null) ? team.Division.Id : null,
                DivisionName = !(team.Division == null) ? team.Division.Name : null,
                StateId = !(team.State == null) ? team.State.Id : null,
                StateName = team.State != null ? team.State.Name : null,
                City = team.City,
                Logo = team.Logo,
                History = team.History,


            };
        }
    }
}
