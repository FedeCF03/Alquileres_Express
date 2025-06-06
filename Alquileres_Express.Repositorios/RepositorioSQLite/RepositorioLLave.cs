using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Repositorios.Context;

namespace Alquileres_Express.Repositorios.RepositorioSQLite;

public class RepositorioLlave : IRepositorioLlave
{
    readonly Alquileres_ExpressContext _context = new Alquileres_ExpressContext();

    public RegistroDeLlave RegistrarEntregaLLavePresencial(int idAlquiler, int idPersonal, int idCliente)
    {

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
}