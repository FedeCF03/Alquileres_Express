using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Enumerativo;

namespace Alquileres_Express.Aplicacion.Interfaces;


public interface IRepositorioComentario
{
    public List<Comentario> ObtenerComentariosPorInmuebleIdAsync(int inmuebleId);
    public bool AgregarComentario(Comentario comentario);
    public Task<bool> EditarComentarioAsync(Comentario comentario);
    public Task<bool> EliminarComentarioAsync(int comentarioId);
    public List<Comentario> ObtenerComentariosPorUsuarioIdAsync(int usuarioId, RolUsuario rolUsuario);
    public List<Comentario> BuscarRespuestasPorComentarioIdAsync(int comentarioId);
}
