using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Repositorios.Context;

namespace Alquileres_Express.Repositorios.RepositorioSQLite;

public class RepositorioLlave : IRepositorioLlave
{
    public List<RegistroDeLlave> ListarRegistroLlaves(int idAlquiler, bool? esEntrega = null)
    {
        using Alquileres_ExpressContext _context = new();
        var llave = _context.Llaves.Where(llave => llave.AlquilerId == idAlquiler);

        // Si esEntrega tiene un valor, filtra por ese criterio
        if (esEntrega.HasValue)
        {
            llave = llave.Where(l => l.EsEntrega == esEntrega.Value);
        }

        // Ordenar por fecha (más reciente primero)
        return llave.OrderByDescending(l => l.FechayHoraRegistro).ToList();
    }
    public void AñadirRegistroDeLlave( RegistroDeLlave registroDeLlave)
    {
        using Alquileres_ExpressContext _context = new();
        if (!_context.Alquileres.Any(a => a.Id == registroDeLlave.AlquilerId))
            throw new InvalidOperationException("Alquiler no encontrado.");
        _context.Llaves.Add(registroDeLlave);
        _context.SaveChanges();
    }
}