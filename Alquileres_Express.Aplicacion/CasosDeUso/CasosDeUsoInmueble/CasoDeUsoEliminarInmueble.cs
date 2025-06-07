namespace Alquileres_Express.Aplicacion.CasosDeUso;

using Alquileres_Express.Aplicacion.Entidades;

using Alquileres_Express.Aplicacion.Interfaces;

public class CasoDeUsoEliminarInmueble(IRepositorioInmueble repositorio)
{
    public bool Ejecutar(int inmuebleId, out string mensajeErrror)
    {
        mensajeErrror = string.Empty;
        try
        {
            repositorio.EliminarInmueble(inmuebleId);
            return true;

        }
        catch (Exception ex)
        {
            // Log the exception or handle it as needed
            mensajeErrror = ex.Message;
            return false;
        }
    }
}