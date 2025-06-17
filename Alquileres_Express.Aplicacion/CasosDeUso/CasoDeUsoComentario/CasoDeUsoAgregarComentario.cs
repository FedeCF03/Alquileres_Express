namespace Alquileres_Express.Aplicacion.CasosDeUso;

using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Aplicacion.Validadores;

public class CasoDeUsoAgregarComentario(IRepositorioComentario repo, ValidadorComentario validador ) : CasoDeUsoComentario(repo)
{


    public bool Ejecutar(Comentario comentario, out List<string> errores)
    {
        errores = validador.Ejecutar(comentario);

        return errores.Count == 0 && _repositorioComentario.AgregarComentario(comentario);
    }
}