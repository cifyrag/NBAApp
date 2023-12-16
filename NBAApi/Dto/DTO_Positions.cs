using NBAApi.Dto;
using NBAApi.Models;

namespace NBAApi.Dto
{
    public class DTO_Positions
    {
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }
        public List<DTO_PositionSummary> Records { get; set; }

        public static DTO_Positions? ToDTO_Positions(List<DTO_PositionSummary> positions, int count, int page=1, int pagesize=50)
        {
            if (positions.Count == null)
            {
                return null;
            }
            var totalP = positions.Count / pagesize > 0 ? positions.Count / pagesize : 1;
            page = page <= 1 ? 1 : page;

            return new DTO_Positions
            {
                TotalRecords = count,
                TotalPages = totalP,
                CurrentPage = page,
                PageSize = pagesize,
                HasPrevious = page > 1,
                 HasNext = page< totalP,
                Records = positions,
            };
        }
    }
}
