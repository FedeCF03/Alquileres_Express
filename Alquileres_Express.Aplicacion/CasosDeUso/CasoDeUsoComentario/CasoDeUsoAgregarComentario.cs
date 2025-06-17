namespace Alquileres_Express.Aplicacion.CasosDeUso;

using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;

public class CasoDeUsoAgregarComentario(IRepositorioComentario repo ) : CasoDeUsoComentario(repo)
{


    public async Task<Comentario> AgregarComentarioAsync(Comentario comentario)
    {
        ArgumentNullException.ThrowIfNull(comentario);

        if (string.IsNullOrWhiteSpace(comentario.Texto))
        {
            throw new ArgumentException("El texto del comentario no puede estar vacío.");
        }

        return await _repositorioComentario.AgregarComentarioAsync(comentario);
    }
}