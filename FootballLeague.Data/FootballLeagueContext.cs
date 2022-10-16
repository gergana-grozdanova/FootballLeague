using FootballLeague.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
//using System.Data.Entity;

namespace FootballLeague.Data
{
    public class FootballLeagueContext:DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }

        public FootballLeagueContext(DbContextOptions<FootballLeagueContext> options):base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Match>().HasOne(m => m.Team1);
            modelBuilder.Entity<Match>().HasOne(m => m.Team2);
            modelBuilder.Entity<Team>().HasMany(t => t.WonMatches);
            modelBuilder.Entity<Team>().HasMany(t => t.LostMatches);
            modelBuilder.Entity<Team>().HasMany(t => t.DrawMatches);
        }
    }
}
