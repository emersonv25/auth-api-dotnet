using Login.Models;
using Microsoft.EntityFrameworkCore;

namespace Login.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().Property(u => u.Username).HasMaxLength(64);
            modelBuilder.Entity<Usuario>()
                .HasData(
                    new Usuario { Id = 1, Username = "admin", Nome = "Administrador", Senha = "admin", Ativo = 1, Cargo = "admin" ,Email = "admin@admin.com" }
                );
        }
    }
}