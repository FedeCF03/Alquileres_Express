using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;
namespace Alquileres_Express.Aplicacion.Servicios;

internal class FiltroDeInmuebles(IRepositorioInmueble repositorioInmueble)
{
    private List<Inmueble> Inmuebles { get; set; } = repositorioInmueble.ObtenerTodosLosInmuebles();

    // public List<Inmueble> FiltrarPorNombre(String nombre)
    // {
    //     Inmuebles = Inmuebles.Where(i => i.Nombre.equals(nombre));
    // }
    // public List<Inmueble> FiltrarPorTipo(String nombre)
    // {

    // }
    // public List<Inmueble> FiltrarPorNombre(String nombre)
    // {

    // }
    // public List<Inmueble> FiltrarPorNombre(String nombre)
    // {

    // }
    // public List<Inmueble> resultado()
    // {

    // }


}