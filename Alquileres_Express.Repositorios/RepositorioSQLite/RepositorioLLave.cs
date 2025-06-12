using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Repositorios.Context;

namespace Alquileres_Express.Repositorios.RepositorioSQLite;

public class RepositorioLlave : IRepositorioLlave
{

    public RegistroDeLlave RegistrarEntregaLLavePresencial(int idAlquiler, int idPersonal, int idCliente)
    {
        using Alquileres_ExpressContext _context = new Alquileres_ExpressContext();
        RegistroDeLlave registro = new RegistroDeLlave
        {
            AlquilerId = idAlquiler,
            ClienteId = idCliente,
            PersonalId = idPersonal,
            FechayHoraRegistro = DateTime.Now,
            EsEntrega = true
        };
        _context.Llaves.Add(registro);
        _context.SaveChanges();
        return registro;
    }

    
public List<RegistroDeLlave> ListarRegistroLlaves(int idAlquiler, bool? esEntrega = null)
{
    using Alquileres_ExpressContext _context = new Alquileres_ExpressContext();
    var llave = _context.Llaves.Where(llave => llave.AlquilerId == idAlquiler);

    // Si esEntrega tiene un valor, filtra por ese criterio
    if (esEntrega.HasValue)
    {
        llave = llave.Where(l => l.EsEntrega == esEntrega.Value);
    }

    // Ordenar por fecha (más reciente primero)
    return llave.OrderByDescending(l => l.FechayHoraRegistro).ToList();
}



    
}