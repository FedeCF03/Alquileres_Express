using Alquileres_Express.Aplicacion.Entidades;
namespace Alquileres_Express.Aplicacion.Interfaces;

public interface IRepositorioGenerico
{
    public void Registrar<T>(T u) where T : Usuario;
    public List<Usuario> Listar();
}