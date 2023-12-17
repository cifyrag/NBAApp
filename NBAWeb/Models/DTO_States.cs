 

namespace NBAWeb.Models
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

        public static DTO_States? ToDTO_States(List<DTO_StateSummary> states, int count, int page=1, int pagesize=50)
        {
            if (states.Count == null)
            {
                return null;
            }
            var totalP = states.Count / pagesize > 0 ? states.Count / pagesize : 1;
            page = page <= 1 ? 1 : page;

            return new DTO_States
            {
                TotalRecords = count,
                TotalPages = totalP,
                CurrentPage = page,
                PageSize = pagesize,
                HasPrevious = page > 1,
                 HasNext = page< totalP,
                Records = states.OrderBy(a => a.Id)
                        .Skip((page - 1) * pagesize)
                        .Take(pagesize)
                        .ToList(),
            };
        }

    }
}
