﻿using NBAApi.Dto;

namespace NBAApi.Dto
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

        public static DTO_Seasons? ToDTO_Seasons(List<DTO_SeasonSummary> seasons, int page=1, int pagesize=50)
        {
            if (seasons.Count == null)
            {
                return null;
            }
            return new DTO_Seasons
            {
                TotalRecords = seasons.Count,
                TotalPages = seasons.Count / pagesize,
                CurrentPage = page,
                PageSize = pagesize,
                HasPrevious = page > 1,
                HasNext = page < seasons.Count,
                Records = seasons,
            };
        }

        
    }
}
