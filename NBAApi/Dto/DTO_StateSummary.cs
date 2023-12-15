using NBAApi.Models;

namespace NBAApi.Dto
{
    public class DTO_StateSummary
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Flag { get; set; }

        public static DTO_StateSummary? ToDTO_StateSummary(State state)
        {
            if (state == null)
            {
                return null;
            }
            return new DTO_StateSummary
            {
                Id = state.Id,
                Name = state.Name,
                Flag = state.Flag,

            };
        }
    }
}
