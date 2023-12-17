 

namespace NBAWeb.Models
{
    public class DTO_SeasonTypes
    {
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }
        public List<DTO_SeasonTypeSummary> Records { get; set; }

        public static DTO_SeasonTypes? ToDTO_SeasonTypes(List<DTO_SeasonTypeSummary> seasonTypes, int count, int page=1, int pagesize=50)
        {
            if (seasonTypes.Count == null)
            {
                return null;
            }
            var totalP = seasonTypes.Count / pagesize > 0 ? seasonTypes.Count / pagesize : 1;
            page = page <= 1 ? 1 : page;

            return new DTO_SeasonTypes
            {
                TotalRecords = count,
                TotalPages = totalP,
                CurrentPage = page,
                PageSize = pagesize,
                HasPrevious = page > 1,
                 HasNext = page< totalP,
                Records = seasonTypes.OrderBy(a => a.Id)
                        .Skip((page - 1) * pagesize)
                        .Take(pagesize)
                        .ToList(),
            };
        }

    }
}
