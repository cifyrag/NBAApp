using NBAApi.Dto;
using NBAApi.Dto;

namespace NBAApi.Dto
{
    public class DTO_Search
    {
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }
        public List<DTO_SearchDetails> Records { get; set; }

         public static DTO_Search? ToDTO_Searchs(List<DTO_SearchDetails> searches, int page, int pagesize)
        {
            if (searches.Count == null)
            {
                return null;
            }
            return new DTO_Search
            {
                TotalRecords = searches.Count,
                TotalPages = searches.Count / pagesize,
                CurrentPage = page,
                PageSize = pagesize,
                HasPrevious = page > 1,
                HasNext = page < searches.Count,
                Records = searches,
            };
        }

    }
}
