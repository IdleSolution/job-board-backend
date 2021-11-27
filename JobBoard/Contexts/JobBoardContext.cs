using JobBoard.Models;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;

namespace JobBoard.Contexts
{
    public class JobBoardContext : DbContext
    {
        public JobBoardContext(DbContextOptions<JobBoardContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().HasData(
                new { Id = 1L,Name="Lena", IsComplete=false },
                new { Id = 2L, Name = "Dzban", IsComplete = true }, 
                new { Id = 3L, Name = "Jan", IsComplete = false }
                );
        }
    }
}