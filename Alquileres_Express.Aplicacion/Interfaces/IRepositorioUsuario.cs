namespace Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Aplicacion.Entidades;

public interface IRepositorioUsuario
{
    public List<Usuario> ListarUsuarios();
    public List<Usuario> ListarRestringido();
}
