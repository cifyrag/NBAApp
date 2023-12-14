using NBAApi.Dto;

namespace NBAApi.Dto
{
    public class DTO_States
    {
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }
        public List<DTO_StateSummary> Records { get; set; }

        public static DTO_States? ToDTO_States(List<DTO_StateSummary> states, int page=1, int pagesize=50)
        {
            if (states.Count == null)
            {
                return null;
            }
            return new DTO_States
            {
                TotalRecords = states.Count,
                TotalPages = states.Count / pagesize,
                CurrentPage = page,
                PageSize = pagesize,
                HasPrevious = page > 1,
                HasNext = page < states.Count,
                Records = states,
            };
        }

    }
}
