using NBAApi.Dto;

namespace NBAApi.Dto
{
    public class DTO_Players
    {
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }
        public List<DTO_PlayerSummary> Records { get; set; }

        public static DTO_Players? ToDTO_Players(List<DTO_PlayerSummary> players, int page=1, int pagesize=50)
        {
            if (players.Count == null)
            {
                return null;
            }
            return new DTO_Players
            {
                TotalRecords = players.Count,
                TotalPages = players.Count / pagesize,
                CurrentPage = page,
                PageSize = pagesize,
                HasPrevious = page > 1,
                HasNext = page < players.Count,
                Records = players,
            };
        }

    }
}
