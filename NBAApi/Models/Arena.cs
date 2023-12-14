using Microsoft.EntityFrameworkCore.Migrations;
using System.ComponentModel.DataAnnotations;

namespace NBAApi.Models
{
    public class Arena
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ArenaStateId { get; set; }
        public int ArenaTeamId { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public int Opened { get; set; }
        public string Photo { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }

        public State State { get; set; }
        public Team Team { get; set; }

        
    }
}
