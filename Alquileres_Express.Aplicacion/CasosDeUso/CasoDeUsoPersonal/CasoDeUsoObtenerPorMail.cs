using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;
namespace Alquileres_Express.Aplicacion.CasosDeUso;

public class CasoDeUsoBuscarPersonalPorCorreo(IRepositorioPersonal _repositorioPersonal)
{
    public Personal? Ejecutar(string correo)
    {
        if (string.IsNullOrWhiteSpace(correo))
        {
            return null; // Retorna null si el correo o la contraseña están vacíos
        }
        return _repositorioPersonal.ObtenerPersonalPorMail(correo );
    }
}