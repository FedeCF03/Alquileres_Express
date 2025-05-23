namespace Alquileres_Express.Repositorios;

using Microsoft.EntityFrameworkCore;
using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;
public class RepositorioInmueble : IRepositorioInmueble
{


    public bool ModificarInmueble(Inmueble inmueble)
    {
        return true;
    }
    public bool EliminarInmueble(int id)
    {
        return true;
    }
    public Inmueble ObtenerInmueblePorId(int id)
    {
        Inmueble x = new Inmueble();
        return x;
    }

    public List<Inmueble> ObtenerInmueblePorNombre(string nombre)
    {
        List<Inmueble> lista = new List<Inmueble>();       //despues usar context
        return lista;
    }
    public List<Inmueble> ObtenerTodosLosInmuebles()
    {
        List<Inmueble> lista = new List<Inmueble>();       //despues usar context
        return lista;
    }
    public List<Inmueble> ObtenerInmueblesPorTipo(string tipo)
    {
        List<Inmueble> lista = new List<Inmueble>();       //despues usar context
        return lista;
    }
    public List<Inmueble> ObtenerInmueblesPorUbicacion(string ubicacion)
    {
        List<Inmueble> lista = new List<Inmueble>();       //despues usar context
        return lista;
    }

    bool IRepositorioInmueble.AgregarInmueble(Inmueble inmueble)
    {
        throw new NotImplementedException();
    }
}