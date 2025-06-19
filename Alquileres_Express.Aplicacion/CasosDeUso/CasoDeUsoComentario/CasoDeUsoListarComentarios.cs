namespace Alquileres_Express.Aplicacion.CasosDeUso;

using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Enumerativo;
using Alquileres_Express.Aplicacion.Interfaces;

public class CasoDeUsoListarComentarios(IRepositorioComentario repo) : CasoDeUsoComentario(repo)
{
    public async Task<List<Comentario>> ListarComentariosPorInmuebleId(int inmuebleId)
    {
        if (inmuebleId <= 0)
        {
            throw new ArgumentException("El ID del inmueble debe ser un número positivo.");
        }
        return await _repositorioComentario.ObtenerComentariosPorInmuebleIdAsync(inmuebleId);
    }
    public async Task<List<Comentario>> ListarComentariosPorUsuarioId(int usuarioId, RolUsuario rolUsuario)
    {
        if (usuarioId <= 0)
        {
            throw new ArgumentException("El ID del usuario debe ser un número positivo.");
        }
        return await _repositorioComentario.ObtenerComentariosPorUsuarioIdAsync(usuarioId, rolUsuario);
    }
    
}