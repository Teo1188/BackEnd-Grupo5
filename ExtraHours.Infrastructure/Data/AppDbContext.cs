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
        public DbSet<ExtraHourType> ExtraHourTypes { get; set; }
        public DbSet<ExtraHour> ExtraHours { get; set; }
        public DbSet<Approval> Approvals { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
           .HasOne<Role>()
           .WithMany()
           .HasForeignKey(u => u.RoleId);

            modelBuilder.Entity<Department>()
           .Property(d => d.Id)
           .UseIdentityColumn(); // Esto asegura el autoincremento en PostgreSQL

            // Configura las relaciones
            modelBuilder.Entity<ExtraHour>()
                .HasOne(eh => eh.User)
                .WithMany()
                .HasForeignKey(eh => eh.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ExtraHour>()
                .HasOne(eh => eh.ExtraHourType)
                .WithMany()
                .HasForeignKey(eh => eh.ExtraHourTypeId);

            modelBuilder.Entity<ExtraHour>()
                .HasOne(eh => eh.ApprovedBy)
                .WithMany()
                .HasForeignKey(eh => eh.ApprovedById)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Approval>()
                .HasOne(a => a.ExtraHour)
                .WithMany()
                .HasForeignKey(a => a.ExtraHourId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<Approval>()
                .HasOne(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
