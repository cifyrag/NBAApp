using NBAApi.Dto;
using NBAApi.Models;

namespace NBAApi.Dto
{
    public class DTO_DivisionSummary
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Logo { get; set; }
        public static DTO_DivisionSummary? ToDTO_DivisionSummary(Division division)
        {
            if (division == null)
            {
                return null;
            }
            return new DTO_DivisionSummary
            {
                Id = division.Id,
                Name = division.Name,
                Logo = division.Logo,
            };
        }
    }
}
