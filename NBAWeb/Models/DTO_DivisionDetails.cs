﻿ 
using NBAWeb.Models;

namespace NBAWeb.Models
{
    public class DTO_DivisionDetails
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Logo { get; set; }
        public List<DTO_TeamSummary> Teams { get; set; }
 

    }
}
