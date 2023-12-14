using NBAApi.Dto;

namespace NBAApi.Dto
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

        public static DTO_SeasonTypes? ToDTO_SeasonTypes(List<DTO_SeasonTypeSummary> seasonTypes, int page=1, int pagesize=50)
        {
            if (seasonTypes.Count == null)
            {
                return null;
            }
            return new DTO_SeasonTypes
            {
                TotalRecords = seasonTypes.Count,
                TotalPages = seasonTypes.Count / pagesize,
                CurrentPage = page,
                PageSize = pagesize,
                HasPrevious = page > 1,
                HasNext = page < seasonTypes.Count,
                Records = seasonTypes,
            };
        }

    }
}
