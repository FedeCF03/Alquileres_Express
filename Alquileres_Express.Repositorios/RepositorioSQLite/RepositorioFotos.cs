namespace Alquileres_Express.Repositorio;

using System.Collections.Generic;
using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Repositorios.Context;

public class RepositorioFoto : IRepositorioFoto
{
    private Alquileres_ExpressContext AlquileresExpressContext = new();
    public void AgregarFoto(Foto foto)
    {

    }

    public void EliminarFoto(int id)
    {
        throw new NotImplementedException();
    }

    public Foto ObtenerFotoPorId(int id)
    {
        throw new NotImplementedException();
    }

    public List<Foto> ObtenerFotosPorInmueble(int idInmueble)
    {
        throw new NotImplementedException();
    }

    public List<Foto> ObtenerTodasLasFotos()
    {
        throw new NotImplementedException();
    }
}