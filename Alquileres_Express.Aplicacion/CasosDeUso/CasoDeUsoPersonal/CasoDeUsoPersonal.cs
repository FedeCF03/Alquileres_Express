using Alquileres_Express.Aplicacion.Interfaces;
namespace Alquileres_Express.Aplicacion.CasosDeUso;

public abstract class CasoDeUsoPersonal(IRepositorioPersonal repositorio)
{
    protected IRepositorioPersonal Repositorio { get; } = repositorio;
}