 

namespace NBAWeb.Models
{
    public class DTO_Seasons
    {
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }
        public List<DTO_SeasonSummary> Records { get; set; }

        public static DTO_Seasons? ToDTO_Seasons(List<DTO_SeasonSummary> seasons, int count, int page=1, int pagesize=50)
        {
            if (seasons.Count == null)
            {
                return null;
            }
            var totalP = seasons.Count / pagesize > 0 ? seasons.Count / pagesize : 1;
            page = page <= 1 ? 1 : page;

            return new DTO_Seasons
            {
                TotalRecords = count,
                TotalPages = totalP,
                CurrentPage = page,
                PageSize = pagesize,
                HasPrevious = page > 1,
                 HasNext = page< totalP,
                Records = seasons,
            };
        }

        
    }
}
