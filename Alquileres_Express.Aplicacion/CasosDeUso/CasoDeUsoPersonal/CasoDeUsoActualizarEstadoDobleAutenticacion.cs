using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;

namespace Alquileres_Express.Aplicacion.CasosDeUso;

public class CasoDeUsoActualizarEstadoDobleAutenticacion(IRepositorioPersonal repositorioPersonal)
{

    public void Ejecutar(int id, string codigo)
    {
        try
        {
            // Validar que el código no sea nulo o vacío
            if (string.IsNullOrWhiteSpace(codigo) || codigo == "0")
            {
                throw new ArgumentException("El código de doble autenticación no puede ser nulo o 0 .", nameof(codigo));
            }

            // Actualizar el estado de doble autenticación
            repositorioPersonal.ActualizarEstadoDobleAutenticacion(id, codigo);
        }
        catch (Exception ex)
        {
            // Manejo de excepciones según sea necesario
            throw new InvalidOperationException("Error al actualizar el estado de doble autenticación.", ex);
        }
    }
}