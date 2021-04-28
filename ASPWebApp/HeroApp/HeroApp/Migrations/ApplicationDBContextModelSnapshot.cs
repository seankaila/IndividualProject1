﻿// <auto-generated />
using System;
using HeroApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HeroApp.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("HeroApp.Models.Hero", b =>
                {
                    b.Property<int>("HeroID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Alias")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("DateOfBirth")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Photo")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Power")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Rival")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("TeamID")
                        .HasColumnType("int");

                    b.HasKey("HeroID");

                    b.HasIndex("TeamID");

                    b.ToTable("Heros");
                });

            modelBuilder.Entity("HeroApp.Team", b =>
                {
                    b.Property<int>("TeamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("EstablishedDate")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Logo")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("RivalTeam")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("TeamName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("TeamID");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("HeroApp.Models.Hero", b =>
                {
                    b.HasOne("HeroApp.Team", "Team")
                        .WithMany("Hero")
                        .HasForeignKey("TeamID");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("HeroApp.Team", b =>
                {
                    b.Navigation("Hero");
                });
#pragma warning restore 612, 618
        }
    }
}
