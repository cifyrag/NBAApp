using NBAApi.Dto;

namespace NBAApi.Dto
{
    public class DTO_Conference
    {
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }
        public List<DTO_ConferenceSummary> Records { get; set; }

        public static DTO_Conference? ToDTO_Conference(List<DTO_ConferenceSummary> conferences, int page=1, int pagesize=50)
        {
            if (conferences.Count == null)
            {
                return null;
            }
            return new DTO_Conference
            {
                TotalRecords = conferences.Count,
                TotalPages = conferences.Count / pagesize,
                CurrentPage = page,
                PageSize = pagesize,
                HasPrevious = page > 1,
                HasNext = page < conferences.Count,
                Records = conferences,
            };
        }
    }
}
