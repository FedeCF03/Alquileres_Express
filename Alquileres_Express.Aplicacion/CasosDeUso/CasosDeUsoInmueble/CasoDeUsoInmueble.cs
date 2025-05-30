using Alquileres_Express.Aplicacion.Interfaces;
namespace Alquileres_Express.Aplicacion.CasosDeUso;

public abstract class CasoDeUsoInmueble(IRepositorioInmueble repositorio)
{
    protected IRepositorioInmueble Repositorio { get; } = repositorio;

}