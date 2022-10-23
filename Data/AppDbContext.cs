using Microsoft.EntityFrameworkCore;
using ApiAuth.Services;
using ApiAuth.Models;

namespace ApiAuth.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // USUARIO
            modelBuilder.Entity<User>().HasKey(u => u.UserId);
            modelBuilder.Entity<User>().Property(u => u.Username).HasMaxLength(64).IsRequired();
            modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique(true);
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique(true);
            modelBuilder.Entity<User>().Property(u => u.Password).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Enabled).HasDefaultValueSql("1").IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Admin).HasDefaultValueSql("0").IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Email).HasMaxLength(256).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.CreatedAt).IsRequired();
            modelBuilder.Entity<User>()
                .HasData(
                    new User { UserId = 1, Username = "admin", FullName = "Administrador", Password = Utils.sha256_hash("admin"), Enabled = true, Admin = true, Email = "admin@admin.com"}
                );
        }

    }
}