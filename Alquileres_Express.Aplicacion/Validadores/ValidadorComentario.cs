using Alquileres_Express.Aplicacion.Entidades;
namespace Alquileres_Express.Aplicacion.Validadores;



public class ValidadorComentario
{
    private List<string>  _errores = [];
    public List<string> Ejecutar(Comentario comentario)
    {
        if (comentario == null)
        {
            _errores.Add("El comentario no puede ser nulo.");
        }
        if (string.IsNullOrWhiteSpace(comentario.Texto))
        {
            _errores.Add("El texto del comentario no puede estar vacío.");
        }
        return _errores;
    }
}