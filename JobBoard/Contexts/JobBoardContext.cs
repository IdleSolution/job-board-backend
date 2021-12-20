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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasData(
                new { Id = 1L, Name = "Qualtrics" },
                new { Id = 2L, Name = "Comarch"},
                new { Id = 3L, Name = "SWM"},
                new { Id = 4L, Name = "Capgemini"}

            );

            modelBuilder.Entity<Review>().HasData(
                new { Id = 1L, CompanyId = 1L, Rating = 5, Position = "Intern", Comment = "Jest niezle", Tag = "JavaScript", Issued = new System.DateTime(2021, 9, 1) },
                new { Id = 2L, CompanyId = 2L, Rating = 1, Position = "Intern", Comment = "Jest niezle", Tag = "C#", Issued = new System.DateTime(2021, 9, 1) },
                new { Id = 3L, CompanyId = 3L, Rating = 5, Position = "Intern", Comment = "Jest niezle", Tag = "Java", Issued = new System.DateTime(2021, 9, 1) },
                new { Id = 4L, CompanyId = 4L, Rating = 5, Position = "Intern", Comment = "Jest niezle", Tag = "Java", Issued = new System.DateTime(2021, 9, 1) }
            );
            modelBuilder.Entity<Interview>().HasData(
                new { Id = 1L, CompanyId = 1L, Difficulty = 5, Position = "Intern", Comment = "Kinda hard", Tag = "JavaScript", Issued = new System.DateTime(2021, 9, 1) },
                new { Id = 2L, CompanyId = 2L, Difficulty = 1, Position = "Intern", Comment = "ez", Tag = "C#", Issued = new System.DateTime(2021, 9, 1) },
                new { Id = 3L, CompanyId = 3L, Difficulty = 1, Position = "Intern", Comment = "ez", Tag = "C#", Issued = new System.DateTime(2021, 9, 1) },
                new { Id = 4L, CompanyId = 4L, Difficulty = 1, Position = "Intern", Comment = "ez", Tag = "C#", Issued = new System.DateTime(2021, 9, 1) }
            );
        }
    }
}