using System.ComponentModel.DataAnnotations;

namespace NBAApi.Models
{
    public class SeasonType
    {
        public string  Id { get; set; }
        public string? Name { get; set; }
        public List<Statistic> Statistics { get; set; }
    }
}
