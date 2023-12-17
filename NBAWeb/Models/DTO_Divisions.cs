 
 
 

namespace NBAWeb.Models
{
    public class DTO_Divisions
    {
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }
        public List<DTO_DivisionSummary> Records { get; set; }

        public static DTO_Divisions? ToDTO_Divisions(List<DTO_DivisionSummary> divisions, int count, int page=1, int pagesize=50)
        {
            if (divisions.Count == null)
            {
                return null;
            }
            var totalP = divisions.Count / pagesize > 0 ? divisions.Count / pagesize : 1;
            page = page <= 1 ? 1 : page;

            return new DTO_Divisions
            {
                TotalRecords = count,
                TotalPages = totalP,
                CurrentPage = page,
                PageSize = pagesize,
                HasPrevious = page > 1,
                 HasNext = page< totalP,
                Records = divisions.OrderBy(a => a.Id)
                        .Skip((page - 1) * pagesize)
                        .Take(pagesize)
                        .ToList(),
            };
        }

    }
}
