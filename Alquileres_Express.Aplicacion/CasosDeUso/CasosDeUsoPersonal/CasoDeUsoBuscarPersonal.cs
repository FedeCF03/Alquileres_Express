using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;
namespace Alquileres_Express.Aplicacion.CasosDeUso;

public class CasoDeUsoBuscarPersonal(IRepositorioPersonal _repositorioPersonal)
{
    public Personal? Ejecutar(string correo, string contraseña)
    {
        if (string.IsNullOrWhiteSpace(correo) || string.IsNullOrWhiteSpace(contraseña))
        {
            return null; // Retorna null si el correo o la contraseña están vacíos
        }
        return _repositorioPersonal.ObtenerPersonalPorMailYContraseña(correo, contraseña);
    }
}