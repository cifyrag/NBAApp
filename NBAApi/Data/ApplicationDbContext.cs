using Microsoft.EntityFrameworkCore;
using NBAApi.Models;

namespace NBAApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<SeasonType> SeasonTypes { get; set; }
        public DbSet<Conference> Conferences { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Statistic> Statistics { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Year> Years { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Arena> Arenas { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Your_Connection_String");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Conference>()
                .HasMany(d => d.Teams)
                .WithOne(e => e.Conference)
                .HasForeignKey(e => e.TeamConferenceId)
 
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Division>()
                .HasMany(d => d.Teams)
                .WithOne(e => e.Division)
                .HasForeignKey(e => e.TeamDivisionId)
 
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<State>()
                .HasMany(d => d.Teams)
                .WithOne(e => e.State)
                .HasForeignKey(e => e.TeamStateId)
 
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<SeasonType>()
                .HasMany(d => d.Statistics)
                .WithOne(e => e.SeasonType)
                .HasForeignKey(e => e.StatisticSeasonTypeId)
 
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Year>()
                .HasMany(d => d.Statistics)
                .WithOne(e => e.Year)
                .HasForeignKey(e => e.StatisticYearId)
 
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Country>()
                .HasMany(d => d.Players)
                .WithOne(e => e.Country)
                .HasForeignKey(e => e.PlayerCountryId)
 
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Position>()
                .HasMany(d => d.Players)
                .WithOne(e => e.Position)
                .HasForeignKey(e => e.PlayerPositionId)
 
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Player>()
                .HasMany(d => d.Statistics)
                .WithOne(e => e.Player)
                .HasForeignKey(e => e.StatisticPlayerId)
 
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Team>()
                .HasMany(d => d.Statistics)
                .WithOne(e => e.Team)
                .HasForeignKey(e => e.StatisticTeamId)
 
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Team>()
                .HasMany(d => d.Arenas)
                .WithOne(e => e.Team)
                .HasForeignKey(e => e.ArenaTeamId)
 
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Team>()
                .HasMany(d => d.Arenas)
                .WithOne(e => e.Team)
                .HasForeignKey(e => e.ArenaTeamId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
