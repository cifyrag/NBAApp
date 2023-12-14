using NBAWeb.Models;
using NBAWeb.Models;
using NBAWeb.Models;

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

        public static DTO_Divisions? ToDTO_Divisions(List<DTO_DivisionSummary> divisions, int page=1, int pagesize=50)
        {
            if (divisions.Count == null)
            {
                return null;
            }
            return new DTO_Divisions
            {
                TotalRecords = divisions.Count,
                TotalPages = divisions.Count / pagesize > 0 ? divisions.Count / pagesize : 1,
                CurrentPage = page,
                PageSize = pagesize,
                HasPrevious = page > 1,
                HasNext = page < divisions.Count,
                Records = divisions,
            };
        }

    }
}
