 

namespace NBAWeb.Models
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

        public static DTO_Conference? ToDTO_Conference(List<DTO_ConferenceSummary> conferences, int count, int page=1, int pagesize=50)
        {
            if (conferences.Count == null)
            {
                return null;
            }
            var totalP = conferences.Count / pagesize > 0 ? conferences.Count / pagesize : 1;
            page = page <= 1 ? 1 : page;
            return new DTO_Conference
            {
                TotalRecords = count,
                TotalPages = totalP,
                CurrentPage = page,
                PageSize = pagesize,
                HasPrevious = page > 1,
                 HasNext = page< totalP,
                Records = conferences.OrderBy(a => a.Id)
                        .Skip((page - 1) * pagesize)
                        .Take(pagesize)
                        .ToList(),
            };
        }
    }
}
