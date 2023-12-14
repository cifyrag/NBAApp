namespace NBAApi.Models
{
    public class Position
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        
        public  ICollection<Player> Players { get; set; }

    }
}
