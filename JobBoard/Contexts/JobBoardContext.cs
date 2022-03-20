using JobBoard.Models.Backend;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace JobBoard.Contexts
{
    public class JobBoardContext : DbContext
    {
        public JobBoardContext(DbContextOptions<JobBoardContext> options)
            : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<Tag> Tags { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Tag> tags = new List<Tag> {
                new Tag { Id = 1, Name = "JS/TS" },
                new Tag { Id = 2, Name = "C#" },
                new Tag { Id = 3, Name = "Java" },
                new Tag { Id = 4, Name = "C/C++" },
                new Tag { Id = 5, Name = "Algorithms" },
                new Tag { Id = 6, Name = "Networks" },
                new Tag { Id = 7, Name = "Databases" },
                new Tag { Id = 8, Name = "Haskell" },
                new Tag { Id = 9, Name = "Python" },
                new Tag { Id = 10, Name = "Golang" },
                new Tag { Id = 11, Name = "Kotlin" }
            };

            modelBuilder.Entity<Tag>().HasData(
                tags
                );

            modelBuilder.Entity<Company>().HasData(
                new { Id = 1L, Name = "Qualtrics" },
                new { Id = 2L, Name = "Comarch"},
                new { Id = 3L, Name = "SWM"},
                new { Id = 4L, Name = "Capgemini"}, 
                new { Id = 5L, Name = "Nokia"}
            );

            modelBuilder.Entity<Review>().HasData(
                new { Id = 1L, CompanyId = 1L, Rating = 5, Position = "Intern", Comment = "Jest niezle", TagId = 1L, Issued = new System.DateTime(2021, 9, 1) },
                new { Id = 2L, CompanyId = 2L, Rating = 1, Position = "Intern", Comment = "Jest niezle", TagId = 2L, Issued = new System.DateTime(2021, 9, 1) },
                new { Id = 3L, CompanyId = 3L, Rating = 5, Position = "Intern", Comment = "Jest niezle", TagId = 3L, Issued = new System.DateTime(2021, 9, 1) },
                new { Id = 4L, CompanyId = 4L, Rating = 5, Position = "Intern", Comment = "Jest niezle", TagId = 3L, Issued = new System.DateTime(2021, 9, 1) },
                new { Id = 5L, CompanyId = 5L, Rating = 5, Position = "Intern", Comment = "Firma jak firma", TagId = 4L, Issued = new System.DateTime(2021, 9, 1) },
                new { Id = 6L, CompanyId = 5L, Rating = 5, Position = "Intern", Comment = "Ja tam polecam", TagId = 11L, Issued = new System.DateTime(2021, 9, 1) },
                new { Id = 7L, CompanyId = 2L, Rating = 3, Position = "Intern", Comment = "Jest niezle", TagId = 8L, Issued = new System.DateTime(2021, 9, 1) },
                new { Id = 8L, CompanyId = 2L, Rating = 2, Position = "Intern", Comment = "Jest niezle", TagId = 10L, Issued = new System.DateTime(2021, 9, 1) }
            );
            modelBuilder.Entity<Interview>().HasData(
                new { Id = 1L, CompanyId = 1L, Difficulty = 5, Position = "Intern", Comment = "Kinda hard", TagId = 5L, Issued = new System.DateTime(2021, 9, 1) },
                new { Id = 2L, CompanyId = 2L, Difficulty = 1, Position = "Intern", Comment = "ez", TagId = 2L, Issued = new System.DateTime(2021, 9, 1) },
                new { Id = 3L, CompanyId = 3L, Difficulty = 1, Position = "Intern", Comment = "ez", TagId = 2L, Issued = new System.DateTime(2021, 9, 1) },
                new { Id = 4L, CompanyId = 4L, Difficulty = 1, Position = "Intern", Comment = "ez", TagId = 2L, Issued = new System.DateTime(2021, 9, 1) }
            );
        }
    }
}