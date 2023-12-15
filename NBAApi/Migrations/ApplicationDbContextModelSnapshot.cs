﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NBAApi.Data;

#nullable disable

namespace NBAApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NBAApi.Models.Arena", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("Capacity")
                        .HasColumnType("int");

                    b.Property<double?>("Lat")
                        .HasColumnType("float");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Lon")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Opened")
                        .HasColumnType("int");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StateId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TeamId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.HasIndex("TeamId");

                    b.ToTable("Arenas");
                });

            modelBuilder.Entity("NBAApi.Models.Conference", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Conferences");
                });

            modelBuilder.Entity("NBAApi.Models.Country", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Flag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("NBAApi.Models.Division", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Divisions");
                });

            modelBuilder.Entity("NBAApi.Models.Player", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Biography")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CountryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("DraftYear")
                        .HasColumnType("int");

                    b.Property<double?>("Height")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PositionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("School")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("PositionId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("NBAApi.Models.Position", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("NBAApi.Models.SeasonType", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SeasonTypes");
                });

            modelBuilder.Entity("NBAApi.Models.State", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Flag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("States");
                });

            modelBuilder.Entity("NBAApi.Models.Statistic", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double?>("AST_TOV")
                        .HasColumnType("float");

                    b.Property<int?>("Assists")
                        .HasColumnType("int");

                    b.Property<int?>("Blocks")
                        .HasColumnType("int");

                    b.Property<int?>("DefensiveRebounds")
                        .HasColumnType("int");

                    b.Property<double?>("Efficiency")
                        .HasColumnType("float");

                    b.Property<int?>("FGAttempts")
                        .HasColumnType("int");

                    b.Property<int?>("FGMade")
                        .HasColumnType("int");

                    b.Property<double?>("FGPercentage")
                        .HasColumnType("float");

                    b.Property<int?>("FTAttempts")
                        .HasColumnType("int");

                    b.Property<int?>("FTMade")
                        .HasColumnType("int");

                    b.Property<double?>("FTPercentage")
                        .HasColumnType("float");

                    b.Property<int?>("GamesPlayed")
                        .HasColumnType("int");

                    b.Property<int?>("MinutesPlayed")
                        .HasColumnType("int");

                    b.Property<int?>("OffensiveRebounds")
                        .HasColumnType("int");

                    b.Property<int?>("PersonalFouls")
                        .HasColumnType("int");

                    b.Property<string>("PlayerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("PointScored")
                        .HasColumnType("int");

                    b.Property<int?>("Rank")
                        .HasColumnType("int");

                    b.Property<int?>("Rebounds")
                        .HasColumnType("int");

                    b.Property<double?>("STL_TOV")
                        .HasColumnType("float");

                    b.Property<string>("SeasonTypeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("Steals")
                        .HasColumnType("int");

                    b.Property<string>("TeamId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("ThreePtFGAttempts")
                        .HasColumnType("int");

                    b.Property<int?>("ThreePtFGMade")
                        .HasColumnType("int");

                    b.Property<double?>("ThreePtFGPercentage")
                        .HasColumnType("float");

                    b.Property<int?>("Turnovers")
                        .HasColumnType("int");

                    b.Property<string>("YearId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.HasIndex("SeasonTypeId");

                    b.HasIndex("TeamId");

                    b.HasIndex("YearId");

                    b.ToTable("Statistics");
                });

            modelBuilder.Entity("NBAApi.Models.Team", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Acronym")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConferenceId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DivisionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("History")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StateId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ConferenceId");

                    b.HasIndex("DivisionId");

                    b.HasIndex("StateId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("NBAApi.Models.Year", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Season")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Years");
                });

            modelBuilder.Entity("NBAApi.Models.Arena", b =>
                {
                    b.HasOne("NBAApi.Models.State", "State")
                        .WithMany("Arenas")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("NBAApi.Models.Team", "Team")
                        .WithMany("Arenas")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("State");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("NBAApi.Models.Player", b =>
                {
                    b.HasOne("NBAApi.Models.Country", "Country")
                        .WithMany("Players")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("NBAApi.Models.Position", "Position")
                        .WithMany("Players")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Country");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("NBAApi.Models.Statistic", b =>
                {
                    b.HasOne("NBAApi.Models.Player", "Player")
                        .WithMany("Statistics")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("NBAApi.Models.SeasonType", "SeasonType")
                        .WithMany("Statistics")
                        .HasForeignKey("SeasonTypeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("NBAApi.Models.Team", "Team")
                        .WithMany("Statistics")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("NBAApi.Models.Year", "Year")
                        .WithMany("Statistics")
                        .HasForeignKey("YearId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Player");

                    b.Navigation("SeasonType");

                    b.Navigation("Team");

                    b.Navigation("Year");
                });

            modelBuilder.Entity("NBAApi.Models.Team", b =>
                {
                    b.HasOne("NBAApi.Models.Conference", "Conference")
                        .WithMany("Teams")
                        .HasForeignKey("ConferenceId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("NBAApi.Models.Division", "Division")
                        .WithMany("Teams")
                        .HasForeignKey("DivisionId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("NBAApi.Models.State", "State")
                        .WithMany("Teams")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Conference");

                    b.Navigation("Division");

                    b.Navigation("State");
                });

            modelBuilder.Entity("NBAApi.Models.Conference", b =>
                {
                    b.Navigation("Teams");
                });

            modelBuilder.Entity("NBAApi.Models.Country", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("NBAApi.Models.Division", b =>
                {
                    b.Navigation("Teams");
                });

            modelBuilder.Entity("NBAApi.Models.Player", b =>
                {
                    b.Navigation("Statistics");
                });

            modelBuilder.Entity("NBAApi.Models.Position", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("NBAApi.Models.SeasonType", b =>
                {
                    b.Navigation("Statistics");
                });

            modelBuilder.Entity("NBAApi.Models.State", b =>
                {
                    b.Navigation("Arenas");

                    b.Navigation("Teams");
                });

            modelBuilder.Entity("NBAApi.Models.Team", b =>
                {
                    b.Navigation("Arenas");

                    b.Navigation("Statistics");
                });

            modelBuilder.Entity("NBAApi.Models.Year", b =>
                {
                    b.Navigation("Statistics");
                });
#pragma warning restore 612, 618
        }
    }
}
