namespace Alquileres_Express.Repositorios.RepositoriosSQLite;

using System.Collections.Generic;
using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Enumerativo;
using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Repositorios.Context;
using Microsoft.EntityFrameworkCore;

public class RepositorioInmueble : IRepositorioInmueble
{

    public int AgregarInmueble(Inmueble inmueble)
    {
        using var _context = new Alquileres_ExpressContext();
        _context.Inmuebles.Add(inmueble);
        _context.SaveChanges();
        return inmueble.Id;
    }   

    public void EliminarInmueble(int id)
    {
        using var _context = new Alquileres_ExpressContext();
        Inmueble inmueble = _context.Inmuebles.Find(id) ?? throw new KeyNotFoundException($"No se encontró un inmueble con el ID {id}");
        _context.Inmuebles.Remove(inmueble);
        _context.SaveChanges();
    }

    public void ModificarInmueble(Inmueble inmueble)
    {

        //lo del nombre se checke en el caso de uso, no es necesario hacerlo aquí
        using var _context = new Alquileres_ExpressContext();
        Inmueble inmuebleExistente = _context.Inmuebles
        .Include(i => i.Fotos)
        .FirstOrDefault(i => i.Id == inmueble.Id)
        ?? throw new KeyNotFoundException($"No se encontró un inmueble con el ID {inmueble.Id}");

        inmuebleExistente.Nombre = inmueble.Nombre;
        inmuebleExistente.Direccion = inmueble.Direccion;
        inmuebleExistente.CoordLat = inmueble.CoordLat;
        inmuebleExistente.CoordLong = inmueble.CoordLong;
        inmuebleExistente.Banios = inmueble.Banios;
        inmuebleExistente.Disponible = inmueble.Disponible;
        inmuebleExistente.Ciudad = inmueble.Ciudad;
        inmuebleExistente.Precio = inmueble.Precio;
        inmuebleExistente.CantidadDeCamas = inmueble.CantidadDeCamas;
        inmuebleExistente.TipoInmueble = inmueble.TipoInmueble;
        _context.SaveChanges();
    }

    public Inmueble ObtenerInmueblePorId(int id)
    {
        using var _context = new Alquileres_ExpressContext();
        var inmueble = _context.Inmuebles.Include(i => i.Fotos).FirstOrDefault(i => i.Id == id) ?? throw new KeyNotFoundException($"No se encontró un inmueble con el ID {id}");
        return inmueble;
    }

    public Inmueble ObtenerInmueblePorNombre(string nombre)
    {
        using var _context = new Alquileres_ExpressContext();
        var inmueble = _context.Inmuebles.Include(i=>i.Fotos).FirstOrDefault(i=> i.Nombre!.Equals(nombre)) ?? throw new KeyNotFoundException($"No se encontró un inmueble con el nombre {nombre}");
        return inmueble;
    }

    public List<Inmueble> ObtenerInmueblesPorTipo(TipoDeInmueble tipo)
    {
        using var _context = new Alquileres_ExpressContext();
        return [.. _context.Inmuebles.Include(i => i.Fotos).Where(i => i.TipoInmueble == tipo)];
    }


    public List<Inmueble> ObtenerTodosLosInmuebles()
    {
        using var _context = new Alquileres_ExpressContext();
        return [.. _context.Inmuebles.Include(i => i.Fotos)];
    }

    public List<Inmueble> ObtenerInmueblesDisponibles()
    {
    using var _context = new Alquileres_ExpressContext();
        return [.. _context.Inmuebles.Where(i => i.Disponible)];
    }
}