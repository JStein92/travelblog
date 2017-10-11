using Microsoft.EntityFrameworkCore;
using TravelBlog.Models;

namespace TravelBlog.Models
{
    public class TravelBlogContext : DbContext
    {

        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Experience> Experiences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            .UseMySql(@"Server=localhost;Port=8889;database=travelblog;uid=root;pwd=root;");
    }
}