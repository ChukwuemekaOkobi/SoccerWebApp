﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using SoccerWebApp.Models;
using System;

namespace SoccerWebApp.Migrations
{
    [DbContext(typeof(SoccerWebAppContext))]
    [Migration("20180927111315_new")]
    partial class @new
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SoccerWebApp.Models.Bank", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountName");

                    b.Property<string>("AccountNumber");

                    b.Property<decimal>("Balance");

                    b.Property<string>("BankName");

                    b.HasKey("Id");

                    b.ToTable("Banks");
                });

            modelBuilder.Entity("SoccerWebApp.Models.Match", b =>
                {
                    b.Property<int>("MatchID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("MatchName")
                        .IsRequired();

                    b.HasKey("MatchID");

                    b.ToTable("Match");
                });

            modelBuilder.Entity("SoccerWebApp.Models.Prediction", b =>
                {
                    b.Property<int>("PredictionID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MatchID");

                    b.Property<int>("TipsterID");

                    b.Property<int?>("matchOutcome");

                    b.Property<DateTime>("predictionDate");

                    b.HasKey("PredictionID");

                    b.HasIndex("MatchID");

                    b.HasIndex("TipsterID");

                    b.ToTable("Prediction");
                });

            modelBuilder.Entity("SoccerWebApp.Models.Tipster", b =>
                {
                    b.Property<int>("TipsterId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Mobile")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Nickname");

                    b.Property<string>("Office")
                        .IsRequired();

                    b.HasKey("TipsterId");

                    b.ToTable("Tipster");
                });

            modelBuilder.Entity("SoccerWebApp.Models.Prediction", b =>
                {
                    b.HasOne("SoccerWebApp.Models.Match", "Match")
                        .WithMany("predictions")
                        .HasForeignKey("MatchID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SoccerWebApp.Models.Tipster", "Tipster")
                        .WithMany("Predictions")
                        .HasForeignKey("TipsterID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}