using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Aplicacion.CasosDeUso;
namespace Alquileres_Express.Aplicacion.Servicios;

public class FiltroDeInmueblesService(IRepositorioInmueble repositorioInmueble)
{
    private readonly List<Filtro<Inmueble>> filtros = [];

    public void AgregarFiltro(Filtro<Inmueble> filtro)
    {
        filtros.Add(filtro);
    }
    public List<Inmueble> FiltrarInmuebles(List<Inmueble> inmuebles)
    {
        var inmueblesFiltrados = repositorioInmueble.ObtenerTodosLosInmuebles();
        filtros.ForEach(filtro => inmuebles.AddRange(filtro.Filtrar(inmueblesFiltrados)));
        return [.. inmueblesFiltrados.Distinct()];
    }

}