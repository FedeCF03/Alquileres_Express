namespace Alquileres_Express.Aplicacion.CasosDeUso;

using Alquileres_Express.Aplicacion.Entidades;

using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Aplicacion.Servicios;

public class CasoDeUsoEliminarInmueble(IRepositorioInmueble repositorio, ServicioFotos servicioFotos)
{
    public bool Ejecutar(int inmuebleId, out string mensajeErrror)
    {
        mensajeErrror = string.Empty;
        try
        {
            Inmueble inmueble = repositorio.ObtenerInmueblePorId(inmuebleId);
            if (repositorio.TieneAlquileresVigentesOPendientes(inmuebleId))
            {
                mensajeErrror = "No se puede eliminar el inmueble porque tiene alquileres asociados.";
                return false;
            }
            servicioFotos.EliminarFotosDelDirectorio(inmueble.Fotos);
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