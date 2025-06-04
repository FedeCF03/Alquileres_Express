namespace Alquileres_Express.Aplicacion.CasosDeUso;
using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Aplicacion.Validadores;

public class CasoDeUsoModificarInmueble(IRepositorioInmueble repositorio, ValidadorInmueble validadorInmueble)
{
    public bool Ejecutar(Inmueble inmueble, out string mensajeError)
    {
        mensajeError = string.Empty;

        if (!validadorInmueble.Ejecutar(inmueble))
        {
            mensajeError = "Alguno de los campos del inmueble está vacío. Por favor, llene todos los campos.";
            return false;
        }
        if (SeRepiteNombre(inmueble))
        {
            mensajeError = "Ya existe un inmueble con el mismo nombre.";
            return false;
        }
        try
        {
            repositorio.ModificarInmueble(inmueble);
            return true;
        }
        catch (Exception ex)
        {
            mensajeError = $"Ocurrió un error al modificar el inmueble: {ex.Message}";
            return false;
        }
    
    }

    private bool SeRepiteNombre(Inmueble inmueble)
    {
        try
        {
            var inmuebleExistente = repositorio.ObtenerInmueblePorNombre(inmueble.Nombre!);
            return true;
        }
        catch (KeyNotFoundException)
        {
            return false;
        }
    }

}
