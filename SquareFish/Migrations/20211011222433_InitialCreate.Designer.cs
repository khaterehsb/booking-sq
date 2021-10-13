﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SquareFish.Infrastructure;

namespace SquareFish.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211011222433_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("SquareFish.Core.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Currency")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasAnnotation("DatabaseGenerated", "Identity");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("SquareFish.Core.BookingLeader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("BookingId")
                        .HasColumnType("integer");

                    b.Property<int>("LeaderId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasAlternateKey("BookingId", "LeaderId");

                    b.HasIndex("LeaderId");

                    b.ToTable("BookingLeader");
                });

            modelBuilder.Entity("SquareFish.Core.Leader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasAnnotation("DatabaseGenerated", "Identity");

                    b.ToTable("Leader");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Michael Scott"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Jim Halpert"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Pam Beesly"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Dwight Schrute"
                        });
                });

            modelBuilder.Entity("SquareFish.Core.BookingLeader", b =>
                {
                    b.HasOne("SquareFish.Core.Booking", "Booking")
                        .WithMany("BookingLeader")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SquareFish.Core.Leader", "Leader")
                        .WithMany("BookingLeader")
                        .HasForeignKey("LeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}