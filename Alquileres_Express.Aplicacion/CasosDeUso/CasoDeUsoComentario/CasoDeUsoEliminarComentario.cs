namespace Alquileres_Express.Aplicacion.CasosDeUso;

using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;

public class CasoDeUsoEliminarComentario(IRepositorioComentario repo ) : CasoDeUsoComentario(repo)
{
    public async Task<bool> EjecutarAsync(int comentarioId)
    {
        if (comentarioId <= 0)
        {
            throw new ArgumentException("El ID del comentario debe ser un número positivo.");
        }

        return await _repositorioComentario.EliminarComentarioAsync(comentarioId);
    }
}