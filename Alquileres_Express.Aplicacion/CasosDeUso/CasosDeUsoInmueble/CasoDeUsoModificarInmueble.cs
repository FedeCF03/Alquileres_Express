namespace Alquileres_Express.Aplicacion.CasosDeUso;
using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Aplicacion.Validadores;

public class CasoDeUsoModificarInmueble(IRepositorioInmueble repositorio, ValidadorInmueble validadorInmueble)
{
    public bool Ejecutar(Inmueble inmueble, out string mensajeError)
    {
        mensajeError = string.Empty;
        try
        {
        validadorInmueble.Ejecutar(inmueble);
        
        if (SeRepiteNombre(inmueble))
        {
            mensajeError = "Ya existe un inmueble con el mismo nombre.";
            return false;
        }
        
            repositorio.ModificarInmueble(inmueble);
            return true;
        }
        catch (Exception ex)
        {
            mensajeError = ex.Message;
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
