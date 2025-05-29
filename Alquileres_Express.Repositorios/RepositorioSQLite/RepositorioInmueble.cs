namespace Alquileres_Express.Repositorios.RepositoriosSQLite;

using System.Collections.Generic;
using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Repositorios.Context;

public class RepositorioInmueble : IRepositorioInmueble
{

    readonly Alquileres_ExpressContext _context = new();

    public bool AgregarInmueble(Inmueble inmueble)
    {
        throw new NotImplementedException();
    }

    public bool EliminarInmueble(int id)
    {
        throw new NotImplementedException();
    }

    public bool ModificarInmueble(Inmueble inmueble)
    {
        throw new NotImplementedException();
    }

    public Inmueble ObtenerInmueblePorId(int id)
    {
        var inmueble = _context.Inmuebles.FirstOrDefault(x => x.Id == id) ?? throw new KeyNotFoundException($"No se encontró un inmueble con el ID {id}");
        return inmueble;
    }

    public List<Inmueble> ObtenerInmueblePorNombre(string nombre)
    {
        throw new NotImplementedException();
    }

    public List<Inmueble> ObtenerInmueblesPorTipo(string tipo)
    {
        throw new NotImplementedException();
    }

    public List<Inmueble> ObtenerInmueblesPorUbicacion(string ubicacion)
    {
        throw new NotImplementedException();
    }

    public List<Inmueble> ObtenerTodosLosInmuebles()
    {
        throw new NotImplementedException();
    }

    public List<Inmueble> ObtenerInmueblesDisponibles()
    {
        return [.. _context.Inmuebles.Where(i => i.disponible)];
    }
}