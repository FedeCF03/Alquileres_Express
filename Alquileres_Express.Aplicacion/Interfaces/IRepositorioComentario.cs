using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Enumerativo;

namespace Alquileres_Express.Aplicacion.Interfaces;


public interface IRepositorioComentario
{
    public Task<List<Comentario>> ObtenerComentariosPorInmuebleIdAsync(int inmuebleId);
    public Task<Comentario> AgregarComentarioAsync(Comentario comentario);
    public Task<Comentario?> EditarComentarioAsync(Comentario comentario);
    public Task<bool> EliminarComentarioAsync(int comentarioId);
    public Task<List<Comentario>?> ObtenerComentariosPorUsuarioIdAsync(int usuarioId, RolUsuario rolUsuario);
}
