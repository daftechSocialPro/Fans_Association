using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using tmretApi.Entities;
using tmretApi.Migrations;

namespace tmretApi.Data
{



    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<DegafiMahber> DefafiMahbers { get; set; }
        public DbSet<DegafiMahberExecutive> DegafiMahberMembers { get; set; }
        public DbSet<SubscribedUsers> SubscribedUsers { get; set; }

        public DbSet<TmretExecutives> TmretExecutives { get; set; }

        public DbSet<MahberExecutives> MahberExecutives { get; set; }

        public DbSet<Matches> Matches { get; set; }

        public DbSet<DegafiSetting> DegafiSettings { get; set; }

        public DbSet<Degafi> Degafi { get; set; }

        public DbSet<Season> Seasons { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<MatchWeek> MatchWeeks { get; set; }

        public DbSet<MacthStats> MacthStats { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<PlayerHistory> PlayerHistories { get; set; }

        public DbSet<PlayerStats> PlayerStats { get; set; }

        public DbSet<SeasonTeams> SeasonTeams { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<IdTemplate>IdTemplates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.email).IsUnique();
            });

            modelBuilder.Entity<MatchWeek>(entity =>
            {
                entity.HasIndex(e => e.matchWeek).IsUnique();
            });

            modelBuilder.Entity<IdTemplate>(entity =>
            {
                entity.HasIndex(e => e.MahberId).IsUnique();
            });

            modelBuilder.Entity<DegafiSetting>(entity =>
            {
                entity.HasIndex(e => e.IdInitial).IsUnique();
            });

            modelBuilder.Entity<Degafi>(entity =>
            {
                entity.HasIndex(e => e.idNumber).IsUnique();
            });


            modelBuilder.Entity<DegafiMahber>()
            .HasMany(dm => dm.MahberExecutives)
            .WithOne()
            .HasForeignKey(me => me.MahberId);

            modelBuilder.Entity<Player>()
            .HasMany(p => p.PlayerStats)
            .WithOne()
            .HasForeignKey(ps => ps.PlayerId);

            modelBuilder.Entity<Player>()
           .HasMany(p => p.MacthStats)
           .WithOne()
           .HasForeignKey(ps => ps.PlayerId);

            modelBuilder.Entity<Player>()
            .HasMany(p => p.PlayerHistory)
            .WithOne()
            .HasForeignKey(ph => ph.PlayerId);

            modelBuilder.Entity<Matches>()
            .HasMany(m => m.MacthStats)
            .WithOne()
            .HasForeignKey(ms => ms.MatchId);


            modelBuilder.Entity<Team>()
            .HasMany(t => t.Players)
            .WithOne()
            .HasForeignKey(pl => pl.CurrentTeamId);



        }
    }





}