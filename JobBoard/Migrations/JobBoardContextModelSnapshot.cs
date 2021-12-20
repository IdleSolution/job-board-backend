﻿// <auto-generated />
using System;
using JobBoard.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JobBoard.Migrations
{
    [DbContext(typeof(JobBoardContext))]
    partial class JobBoardContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("JobBoard.Models.Backend.Company", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Qualtrics"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Comarch"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "SWM"
                        },
                        new
                        {
                            Id = 4L,
                            Name = "Capgemini"
                        });
                });

            modelBuilder.Entity("JobBoard.Models.Backend.Interview", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("CompanyId")
                        .HasColumnType("bigint");

                    b.Property<int>("Difficulty")
                        .HasColumnType("int");

                    b.Property<DateTime>("Issued")
                        .HasColumnType("datetime");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Tag")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Interviews");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Comment = "Kinda hard",
                            CompanyId = 1L,
                            Difficulty = 5,
                            Issued = new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Position = "Intern",
                            Tag = "JavaScript"
                        },
                        new
                        {
                            Id = 2L,
                            Comment = "ez",
                            CompanyId = 2L,
                            Difficulty = 1,
                            Issued = new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Position = "Intern",
                            Tag = "C#"
                        },
                        new
                        {
                            Id = 3L,
                            Comment = "ez",
                            CompanyId = 3L,
                            Difficulty = 1,
                            Issued = new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Position = "Intern",
                            Tag = "C#"
                        },
                        new
                        {
                            Id = 4L,
                            Comment = "ez",
                            CompanyId = 4L,
                            Difficulty = 1,
                            Issued = new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Position = "Intern",
                            Tag = "C#"
                        });
                });

            modelBuilder.Entity("JobBoard.Models.Backend.Review", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("CompanyId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("From")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("Issued")
                        .HasColumnType("datetime");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("Tag")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("To")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Comment = "Jest niezle",
                            CompanyId = 1L,
                            Issued = new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Position = "Intern",
                            Rating = 5,
                            Tag = "JavaScript"
                        },
                        new
                        {
                            Id = 2L,
                            Comment = "Jest niezle",
                            CompanyId = 2L,
                            Issued = new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Position = "Intern",
                            Rating = 1,
                            Tag = "C#"
                        },
                        new
                        {
                            Id = 3L,
                            Comment = "Jest niezle",
                            CompanyId = 3L,
                            Issued = new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Position = "Intern",
                            Rating = 5,
                            Tag = "Java"
                        },
                        new
                        {
                            Id = 4L,
                            Comment = "Jest niezle",
                            CompanyId = 4L,
                            Issued = new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Position = "Intern",
                            Rating = 5,
                            Tag = "Java"
                        });
                });

            modelBuilder.Entity("JobBoard.Models.Backend.Interview", b =>
                {
                    b.HasOne("JobBoard.Models.Backend.Company", "Company")
                        .WithMany("Interviews")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("JobBoard.Models.Backend.Review", b =>
                {
                    b.HasOne("JobBoard.Models.Backend.Company", "Company")
                        .WithMany("Reviews")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("JobBoard.Models.Backend.Company", b =>
                {
                    b.Navigation("Interviews");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
