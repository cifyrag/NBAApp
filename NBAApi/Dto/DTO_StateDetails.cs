using NBAApi.Models;
using NBAApi.Dto;

namespace NBAApi.Dto
{
    public class DTO_StateDetails
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Flag { get; set; }
        public List<DTO_TeamSummary> Teams { get; set; }
        public List<DTO_ArenaSummary> Arenas { get; set; }

        public static DTO_StateDetails? ToDTO_StateDetails(State state)
        {
            if (state == null)
            {
                return null;
            }
            return new DTO_StateDetails
            {
                Id = state.Id,
                Name = state.Name,
                Flag = state.Flag,
                Teams = state.Teams.Select(x => DTO_TeamSummary.ToDTO_TeamSummary(x)).ToList(),
                Arenas = state.Arenas.Select(x => DTO_ArenaSummary.ToDTO_ArenaSummary(x)).ToList(),
            };
        }
    }
}
