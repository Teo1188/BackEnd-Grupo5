using Microsoft.EntityFrameworkCore;
using ExtraHours.Core.Models;

namespace ExtraHours.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}     
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Department> Departments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
           .HasOne<Role>()
           .WithMany()
           .HasForeignKey(u => u.RoleId);

            modelBuilder.Entity<Department>()
           .Property(d => d.Id)
           .UseIdentityColumn(); // Esto asegura el autoincremento en PostgreSQL
        }
    }
}
