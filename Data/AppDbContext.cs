// AppDbContext.cs
using Microsoft.EntityFrameworkCore;
using MiProyectoWeb.Models; 

namespace MiProyectoWeb.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        // Aquí se definen las tablas que se utilizarán en la base de datos 
        public DbSet<Producto> Productos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>()
                .Property(p => p.Precio)
                .HasColumnType("decimal(18,2)");
        }
    }
}
