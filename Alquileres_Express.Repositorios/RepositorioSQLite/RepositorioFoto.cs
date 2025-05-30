namespace Alquileres_Express.Repositorio;

using System.Collections.Generic;
using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Repositorios.Context;

public class RepositorioFoto : IRepositorioFoto
{
    public int AgregarFoto(Foto foto)
    {
        using Alquileres_ExpressContext AlquileresExpressContext = new();
        AlquileresExpressContext.Fotos.Add(foto);
        AlquileresExpressContext.SaveChanges();
        return foto.Id;
    }

    public void AgregarFotos(List<Foto> fotos)
    {
        using Alquileres_ExpressContext AlquileresExpressContext = new();

        AlquileresExpressContext.Fotos.AddRange(fotos);
        AlquileresExpressContext.SaveChanges();
    }

    public void EliminarFoto(int id)
    {
        using Alquileres_ExpressContext AlquileresExpressContext = new();
        Foto? foto = AlquileresExpressContext.Fotos.Find(id);
        if (foto != null)
        {
            AlquileresExpressContext.Fotos.Remove(foto);
            AlquileresExpressContext.SaveChanges();
        }
        else
        {
            throw new KeyNotFoundException($"Foto with id {id} not found.");
        }
    }

    public List<Foto> ObtenerFotosPorInmueble(int idInmueble)
    {
        using Alquileres_ExpressContext AlquileresExpressContext = new();
        return AlquileresExpressContext.Fotos.Where(f => f.InmuebleId == idInmueble).ToList();

    }


    public List<Foto> ObtenerTodasLasFotos()
    {
        using Alquileres_ExpressContext AlquileresExpressContext = new();
        return AlquileresExpressContext.Fotos.ToList();
    }

    public Foto ObtenerFotoPorId(int id)
    {
        using Alquileres_ExpressContext AlquileresExpressContext = new();
        Foto? foto = AlquileresExpressContext.Fotos.Find(id);
        if (foto == null)
        {
            throw new KeyNotFoundException($"Foto with id {id} not found.");
        }
        return foto;
    }

}