namespace NBAApi.Models
{
    public class SeasonType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Statistic> Statistics { get; set; }
    }
}
