 
 
using NBAWeb.Models;

namespace NBAWeb.Models
{
    public class DTO_Arenas
    {
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }
        public List<DTO_ArenaSummary> Records { get; set; }

        public static DTO_Arenas? ToDTO_Arenas(List<DTO_ArenaSummary> arenas, int count, int page=1, int pagesize=50)
        {
            if (arenas.Count == null)
            {
                return null;
            }
            var totalP = arenas.Count / pagesize > 0 ? arenas.Count / pagesize : 1;
            page = page <= 1 ? 1 : page;
            return new DTO_Arenas
            {
                TotalRecords = count,
                TotalPages = totalP,
                CurrentPage = page,
                PageSize = pagesize,
                HasPrevious = page>1,
                 HasNext = page< totalP,
                Records = arenas.OrderBy(a => a.Id)
                        .Skip((page - 1) * pagesize)
                        .Take(pagesize)
                        .ToList(),
            };
        }
    }
}
