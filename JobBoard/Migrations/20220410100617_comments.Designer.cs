﻿// <auto-generated />
using System;
using JobBoard.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JobBoard.Migrations
{
    [DbContext(typeof(JobBoardContext))]
    [Migration("20220410100617_comments")]
    partial class comments
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                        },
                        new
                        {
                            Id = 5L,
                            Name = "Nokia"
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

                    b.Property<long?>("TagId")
                        .HasColumnType("bigint");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("TagId");

                    b.HasIndex("UserId");

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
                            TagId = 5L,
                            UserId = "dummyId"
                        },
                        new
                        {
                            Id = 2L,
                            Comment = "ez",
                            CompanyId = 2L,
                            Difficulty = 1,
                            Issued = new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Position = "Intern",
                            TagId = 2L,
                            UserId = "dummyId"
                        },
                        new
                        {
                            Id = 3L,
                            Comment = "ez",
                            CompanyId = 3L,
                            Difficulty = 1,
                            Issued = new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Position = "Intern",
                            TagId = 2L,
                            UserId = "dummyId"
                        },
                        new
                        {
                            Id = 4L,
                            Comment = "ez",
                            CompanyId = 4L,
                            Difficulty = 1,
                            Issued = new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Position = "Intern",
                            TagId = 2L,
                            UserId = "dummyId"
                        });
                });

            modelBuilder.Entity("JobBoard.Models.Backend.InterviewComment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("InterviewId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Issued")
                        .HasColumnType("datetime");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("InterviewId");

                    b.HasIndex("UserId");

                    b.ToTable("InterviewComment");
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

                    b.Property<long?>("TagId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("To")
                        .HasColumnType("datetime");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("TagId");

                    b.HasIndex("UserId");

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
                            TagId = 1L,
                            UserId = "dummyId"
                        },
                        new
                        {
                            Id = 2L,
                            Comment = "Jest niezle",
                            CompanyId = 2L,
                            Issued = new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Position = "Intern",
                            Rating = 1,
                            TagId = 2L,
                            UserId = "dummyId"
                        },
                        new
                        {
                            Id = 3L,
                            Comment = "Jest niezle",
                            CompanyId = 3L,
                            Issued = new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Position = "Intern",
                            Rating = 5,
                            TagId = 3L,
                            UserId = "dummyId"
                        },
                        new
                        {
                            Id = 4L,
                            Comment = "Jest niezle",
                            CompanyId = 4L,
                            Issued = new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Position = "Intern",
                            Rating = 5,
                            TagId = 3L,
                            UserId = "dummyId"
                        },
                        new
                        {
                            Id = 5L,
                            Comment = "Firma jak firma",
                            CompanyId = 5L,
                            Issued = new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Position = "Intern",
                            Rating = 5,
                            TagId = 4L,
                            UserId = "dummyId"
                        },
                        new
                        {
                            Id = 6L,
                            Comment = "Ja tam polecam",
                            CompanyId = 5L,
                            Issued = new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Position = "Intern",
                            Rating = 5,
                            TagId = 11L,
                            UserId = "dummyId"
                        },
                        new
                        {
                            Id = 7L,
                            Comment = "Jest niezle",
                            CompanyId = 2L,
                            Issued = new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Position = "Intern",
                            Rating = 3,
                            TagId = 8L,
                            UserId = "dummyId"
                        },
                        new
                        {
                            Id = 8L,
                            Comment = "Jest niezle",
                            CompanyId = 2L,
                            Issued = new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Position = "Intern",
                            Rating = 2,
                            TagId = 10L,
                            UserId = "dummyId"
                        },
                        new
                        {
                            Id = 9L,
                            Comment = "Jest niezle",
                            CompanyId = 4L,
                            From = new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Issued = new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Position = "Intern",
                            Rating = 5,
                            TagId = 3L,
                            To = new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = "dummyId"
                        },
                        new
                        {
                            Id = 10L,
                            Comment = "Jest niezle",
                            CompanyId = 4L,
                            From = new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Issued = new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Position = "Intern",
                            Rating = 5,
                            TagId = 3L,
                            UserId = "dummyId"
                        });
                });

            modelBuilder.Entity("JobBoard.Models.Backend.ReviewComment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Issued")
                        .HasColumnType("datetime");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("ReviewId")
                        .HasColumnType("bigint");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("ReviewId");

                    b.HasIndex("UserId");

                    b.ToTable("ReviewComment");
                });

            modelBuilder.Entity("JobBoard.Models.Backend.Tag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "JS/TS"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "C#"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Java"
                        },
                        new
                        {
                            Id = 4L,
                            Name = "C/C++"
                        },
                        new
                        {
                            Id = 5L,
                            Name = "Algorithms"
                        },
                        new
                        {
                            Id = 6L,
                            Name = "Networks"
                        },
                        new
                        {
                            Id = 7L,
                            Name = "Databases"
                        },
                        new
                        {
                            Id = 8L,
                            Name = "Haskell"
                        },
                        new
                        {
                            Id = 9L,
                            Name = "Python"
                        },
                        new
                        {
                            Id = 10L,
                            Name = "Golang"
                        },
                        new
                        {
                            Id = 11L,
                            Name = "Kotlin"
                        });
                });

            modelBuilder.Entity("JobBoard.Models.Backend.User", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "dummyId",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "0f477b15-858c-4a4d-bf69-e1eba176c11d",
                            Email = "dummy",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "f1027d6a-3192-4fa8-add8-c7e79e98981f",
                            TwoFactorEnabled = false,
                            UserName = "dummy"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityRole");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(200)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("JobBoard.Models.Backend.Role", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityRole");

                    b.HasDiscriminator().HasValue("Role");
                });

            modelBuilder.Entity("JobBoard.Models.Backend.Interview", b =>
                {
                    b.HasOne("JobBoard.Models.Backend.Company", "Company")
                        .WithMany("Interviews")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobBoard.Models.Backend.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId");

                    b.HasOne("JobBoard.Models.Backend.User", "User")
                        .WithMany("Interviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Tag");

                    b.Navigation("User");
                });

            modelBuilder.Entity("JobBoard.Models.Backend.InterviewComment", b =>
                {
                    b.HasOne("JobBoard.Models.Backend.Interview", null)
                        .WithMany("Comments")
                        .HasForeignKey("InterviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobBoard.Models.Backend.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("JobBoard.Models.Backend.Review", b =>
                {
                    b.HasOne("JobBoard.Models.Backend.Company", "Company")
                        .WithMany("Reviews")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobBoard.Models.Backend.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId");

                    b.HasOne("JobBoard.Models.Backend.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Tag");

                    b.Navigation("User");
                });

            modelBuilder.Entity("JobBoard.Models.Backend.ReviewComment", b =>
                {
                    b.HasOne("JobBoard.Models.Backend.Review", "Review")
                        .WithMany("Comments")
                        .HasForeignKey("ReviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobBoard.Models.Backend.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Review");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("JobBoard.Models.Backend.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("JobBoard.Models.Backend.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobBoard.Models.Backend.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("JobBoard.Models.Backend.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JobBoard.Models.Backend.Company", b =>
                {
                    b.Navigation("Interviews");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("JobBoard.Models.Backend.Interview", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("JobBoard.Models.Backend.Review", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("JobBoard.Models.Backend.User", b =>
                {
                    b.Navigation("Interviews");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}