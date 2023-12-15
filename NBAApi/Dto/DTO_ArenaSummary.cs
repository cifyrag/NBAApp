using NBAApi.Dto;
using NBAApi.Models;

namespace NBAApi.Dto
{
    public class DTO_ArenaSummary
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? StateId { get; set; }
        public string? StateName { get; set; }
        public string? TeamId { get; set; }
        public string? TeamName { get; set; }
        public string? TeamAcronym { get; set; }
        public string? Location { get; set; }
        public int? Capacity { get; set; }
        public int? Opened { get; set; }
        public string? Photo { get; set; }

        public static DTO_ArenaSummary? ToDTO_ArenaSummary(Arena arena)
        {
            if (arena == null)
            {
                return null;
            }
            return new DTO_ArenaSummary
            {
                Id = arena.Id,
                Name = arena.Name,
                StateId = arena.State.Id,
                StateName = arena.State.Name,
                TeamId = arena.Team.Id,
                TeamName = arena.Team.Name,
                TeamAcronym = arena.Team.Acronym,
                Location = arena.Location,
                Capacity = arena.Capacity,
                Opened = arena.Opened,
                Photo = arena.Photo,

            };
        }
    }
}
