using Microsoft.EntityFrameworkCore;
using Alquileres_Express.Aplicacion.Entidades;
namespace Alquileres_Express.Repositorios.Context;


public class Alquileres_ExpressContext : DbContext
{
#nullable disable
    public DbSet<Inmueble> Inmuebles { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Personal> Personal { get; set; }
    public DbSet<Alquiler> Alquileres { get; set; }
    public DbSet<RegistroDeLlave> Llaves { get; set; }
    public DbSet<Foto> Fotos { get; set; }
#nullable restore

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Alquiler_Express.sqlite");
    }

}