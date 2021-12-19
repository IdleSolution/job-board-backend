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
                new { Id = 1L, Name = "Qualtrics" }
                );

            modelBuilder.Entity<Review>().HasData(
                new { Id = 1L, CompanyId = 1L, Rating = 5, Position = "Intern", Comment = "Jest niezle", Tag = "JavaScript", Issued = new System.DateTime(2021, 9, 1) }
                );
            modelBuilder.Entity<Interview>().HasData(
                new { Id = 1L, CompanyId = 1L, Difficulty = 5, Position = "Intern", Comment = "Kinda hard", Tag = "JavaScript", Issued = new System.DateTime(2021, 9, 1) }
                );
        }
    }
}