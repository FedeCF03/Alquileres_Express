namespace Alquileres_Express.Aplicacion.CasosDeUso;

using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;
public class CasoDeUsoValidarCodigoDeSeguridad(IRepositorioPersonal _repositorioPersonal)
{

    public Personal? Ejecutar(string correo, string codigo)
    {
        try
        {
            var personal = _repositorioPersonal.ValidarCodigoDeSeguridad(correo, codigo);
            return personal;
        }
        catch (Exception ex)
        {
            // Manejo de excepciones según sea necesario
            throw new InvalidOperationException("Error al validar el código de seguridad.", ex);
        }
    }
}