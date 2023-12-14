using NBAWeb.Models;

namespace NBAWeb.Models
{
    public class DTO_Teams
    {
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }
        public List<DTO_TeamSummary> Records { get; set; }

        public static DTO_Teams? ToDTO_Teams(List<DTO_TeamSummary> teams, int page=1, int pagesize=50)
        {
            if (teams.Count == null)
            {
                return null;
            }
            return new DTO_Teams
            {
                TotalRecords = teams.Count,
                TotalPages = teams.Count / pagesize,
                CurrentPage = page,
                PageSize = pagesize,
                HasPrevious = page > 1,
                HasNext = page < teams.Count,
                Records = teams,
            };
        }

    }
}
