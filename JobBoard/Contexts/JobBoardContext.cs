using JobBoard.Models.Backend;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection;
using JobBoard.Configuration;
using Microsoft.AspNetCore.Identity;

namespace JobBoard.Contexts
{
    public class JobBoardContext : IdentityDbContext<User>
    {
        public JobBoardContext(DbContextOptions<JobBoardContext> options) : base(options)
        {

        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<InterviewComment> InterviewComments { get; set; }
        public DbSet<ReviewComment> ReviewComments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity => entity.Property(m => m.NormalizedEmail).HasMaxLength(200));
            modelBuilder.Entity<User>(entity => entity.Property(m => m.Id).HasMaxLength(200));
            modelBuilder.Entity<User>(entity => entity.Property(m => m.NormalizedUserName).HasMaxLength(200));

            modelBuilder.Entity<Role>(entity => entity.Property(m => m.NormalizedName).HasMaxLength(200));
            modelBuilder.Entity<Role>(entity => entity.Property(m => m.Id).HasMaxLength(200));

            modelBuilder.Entity<Interview>()
                .HasOne(i => i.User)
                .WithMany(u => u.Interviews)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(i => i.Roles)
                .WithMany(u => u.Users);

            modelBuilder.Entity<Role>().HasData(
                new Role{ Name = "Admin", NormalizedName = "Admin".ToUpper() },
                new Role{ Name = "Moderator", NormalizedName = "Moderator".ToUpper()}
                );
                
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

            User dummy = new User { Email = "dummy", Id = "dummyId", UserName = "dummy" };

            modelBuilder.Entity<User>().HasData(
                    dummy
                );

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
                new { Id = 1L, CompanyId = 1L, Rating = 5, Position = "Intern", Comment = "Jest niezle", TagId = 1L, Issued = new System.DateTime(2021, 9, 1), UserId = dummy.Id },
                new { Id = 2L, CompanyId = 2L, Rating = 1, Position = "Intern", Comment = "Jest niezle", TagId = 2L, Issued = new System.DateTime(2021, 9, 1), UserId = dummy.Id },
                new { Id = 3L, CompanyId = 3L, Rating = 5, Position = "Intern", Comment = "Jest niezle", TagId = 3L, Issued = new System.DateTime(2021, 9, 1), UserId = dummy.Id },
                new { Id = 4L, CompanyId = 4L, Rating = 5, Position = "Intern", Comment = "Jest niezle", TagId = 3L, Issued = new System.DateTime(2021, 9, 1), UserId = dummy.Id },
                new { Id = 5L, CompanyId = 5L, Rating = 5, Position = "Intern", Comment = "Firma jak firma", TagId = 4L, Issued = new System.DateTime(2021, 9, 1), UserId = dummy.Id },
                new { Id = 6L, CompanyId = 5L, Rating = 5, Position = "Intern", Comment = "Ja tam polecam", TagId = 11L, Issued = new System.DateTime(2021, 9, 1), UserId = dummy.Id },
                new { Id = 7L, CompanyId = 2L, Rating = 3, Position = "Intern", Comment = "Jest niezle", TagId = 8L, Issued = new System.DateTime(2021, 9, 1), UserId = dummy.Id },
                new { Id = 8L, CompanyId = 2L, Rating = 2, Position = "Intern", Comment = "Jest niezle", TagId = 10L, Issued = new System.DateTime(2021, 9, 1), UserId = dummy.Id },
                new { Id = 9L, CompanyId = 4L, Rating = 5, Position = "Intern", Comment = "Jest niezle", TagId = 3L, From = new System.DateTime(2021, 9, 1), To = new System.DateTime(2021, 9, 1), Issued = new System.DateTime(2021, 9, 1), UserId = dummy.Id },
                new { Id = 10L, CompanyId = 4L, Rating = 5, Position = "Intern", Comment = "Jest niezle", TagId = 3L, From = new System.DateTime(2021, 9, 1), Issued = new System.DateTime(2021, 9, 1), UserId = dummy.Id }
            );
            modelBuilder.Entity<Interview>().HasData(
                new { Id = 1L, CompanyId = 1L, Difficulty = 5, Position = "Intern", Comment = "Kinda hard", TagId = 5L, Issued = new System.DateTime(2021, 9, 1), UserId = dummy.Id },
                new { Id = 2L, CompanyId = 2L, Difficulty = 1, Position = "Intern", Comment = "ez", TagId = 2L, Issued = new System.DateTime(2021, 9, 1), UserId = dummy.Id },
                new { Id = 3L, CompanyId = 3L, Difficulty = 1, Position = "Intern", Comment = "ez", TagId = 2L, Issued = new System.DateTime(2021, 9, 1), UserId = dummy.Id },
                new { Id = 4L, CompanyId = 4L, Difficulty = 1, Position = "Intern", Comment = "ez", TagId = 2L, Issued = new System.DateTime(2021, 9, 1), UserId = dummy.Id }
            );
        }
    }
}