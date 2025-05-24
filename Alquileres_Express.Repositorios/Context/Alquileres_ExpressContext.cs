using Microsoft.EntityFrameworkCore;
using Alquileres_Express.Aplicacion.Entidades;
namespace Alquileres_Express.Repositorios.Context;

public class Alquileres_ExpressContext : DbContext
{
    public DbSet<Inmueble> Inmuebles { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Alquiler> Alquileres { get; set; }
    public DbSet<Codigo> Codigos { get; set; }

    public DbSet<RegistroDeLlave> Llaves { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("data source=SGE.sqlite");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Usuario>().ToTable("Usuarios");
        modelBuilder.Entity<Usuario>().HasKey(c => c.ID);
        //modelBuilder.Entity<Expediente>().ToTable("Expedientes");
        modelBuilder.Entity<Inmueble>().HasKey(d => d.nombre);
    }
}