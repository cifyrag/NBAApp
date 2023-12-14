using System.Numerics;

namespace NBAApi.Models
{
    public class Country
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Flag { get; set; }

       
        public  ICollection<Player> Players { get; set; }
    }

}

