﻿using NBAApi.Dto;

namespace NBAApi.Dto
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

        public static DTO_Teams? ToDTO_Teams(List<DTO_TeamSummary> teams, int count, int page=1, int pagesize=50)
        {
            if (teams.Count == null)
            {
                return null;
            }
            var totalP = teams.Count / pagesize > 0 ? teams.Count / pagesize : 1;
            page = page <= 1 ? 1 : page;

            return new DTO_Teams
            {
                TotalRecords = count,
                TotalPages = totalP,
                CurrentPage = page,
                PageSize = pagesize,
                HasPrevious = page > 1,
                 HasNext = page< totalP,
                Records = teams,
            };
        }

    }
}
