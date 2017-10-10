using Microsoft.EntityFrameworkCore;
using TravelBlog.Models;

namespace TravelBlog.Models
{
    public class TravelBlogContext : DbContext
    {
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Experience> Experiences { get; set; }
        public virtual DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExperiencePerson>()
                        .HasKey(item => new { item.ExperienceId, item.PersonId });

            modelBuilder.Entity<ExperiencePerson>()
                        .HasOne(item => item.Experience)
                        .WithMany(item => item.ExperiencePerson)
                        .HasForeignKey(item => item.ExperienceId);

            modelBuilder.Entity<ExperiencePerson>()
                        .HasOne(item => item.Person)
                        .WithMany(item => item.ExperiencePerson)
                        .HasForeignKey(item => item.PersonId);

            modelBuilder.Entity<LocationPerson>()
                        .HasKey(item => new { item.LocationId, item.PersonId });

            modelBuilder.Entity<LocationPerson>()
                        .HasOne(item => item.Location)
                        .WithMany(item => item.LocationPerson)
                        .HasForeignKey(item => item.LocationId);

            modelBuilder.Entity<LocationPerson>()
                        .HasOne(item => item.Person)
                        .WithMany(item => item.LocationPerson)
                        .HasForeignKey(item => item.PersonId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            .UseMySql(@"Server=localhost;Port=8889;database=travelblog;uid=root;pwd=root;");
    }
}