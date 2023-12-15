using NBAApi.Dto;
using NBAApi.Models;

namespace NBAApi.Dto
{
    public class DTO_DivisionDetails
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Logo { get; set; }
        public List<DTO_TeamSummary> Teams { get; set; }


        public static DTO_DivisionDetails? ToDTO_DivisionDetails(Division division)
        {
            if (division == null)
            {
                return null;
            }
            return new DTO_DivisionDetails
            {
                Id = division.Id,
                Name = division.Name,
                Logo = division.Logo,
                Teams = division.Teams.Select(x => DTO_TeamSummary.ToDTO_TeamSummary(x)).ToList(),
            };
        }

    }
}
