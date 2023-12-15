using System.ComponentModel.DataAnnotations;

namespace NBAApi.Models
{
    public class Year
    {
        [Key]
        public int Id { get; set; }
        public string Season { get; set; }
        
        public ICollection<Statistic> Statistics { get; set; }

    }
}
