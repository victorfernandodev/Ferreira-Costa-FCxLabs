using Microsoft.EntityFrameworkCore;
using UsersAPI.Models;

namespace UsersAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        //Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(c => c.Id);

            modelBuilder.Entity<User>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
