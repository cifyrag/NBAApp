 
 

namespace NBAWeb.Models
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

         public static DTO_Search? ToDTO_Searchs(List<DTO_SearchDetails> searches,int count, int page, int pagesize)
        {
            if (searches.Count == null)
            {
                return null;
            }
            var totalP = searches.Count / pagesize > 0 ? searches.Count / pagesize : 1;
            page = page <= 1 ? 1 : page;

            return new DTO_Search
            {
                TotalRecords = count,
                TotalPages = totalP,
                CurrentPage = page,
                PageSize = pagesize,
                HasPrevious = page > 1,
                 HasNext = page< totalP,
                Records = searches,
            };
        }

    }
}
