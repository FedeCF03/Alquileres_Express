using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;

namespace Alquileres_Express.Aplicacion.CasosDeUso;
public class CasoDeUsoBuscarRespuestas (IRepositorioComentario repositorioComentario)
{
    public List<Comentario> Ejecutar(int comentarioId)
    {
        if (comentarioId <= 0)
        {
            throw new ArgumentException("El ID de la pregunta debe ser un número positivo.");
        }

        return repositorioComentario.BuscarRespuestasPorComentarioIdAsync(comentarioId);
    }
}