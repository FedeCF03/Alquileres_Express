using Alquileres_Express.Aplicacion.Interfaces;
namespace Alquileres_Express.Aplicacion.CasosDeUso;

public abstract class CasoDeUsoCliente(IRepositorioCliente repositorio)
{
    protected IRepositorioCliente Repositorio { get; } = repositorio;
}