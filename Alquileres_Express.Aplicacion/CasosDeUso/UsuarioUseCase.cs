using Alquileres_Express.Aplicacion.Interfaces;
namespace Alquileres_Express.Aplicacion.CasosDeUso;

public abstract class CasoDeUsoUsuario(IRepositorioUsuario repositorio)
{
    protected IRepositorioUsuario Repositorio { get; } = repositorio;
}