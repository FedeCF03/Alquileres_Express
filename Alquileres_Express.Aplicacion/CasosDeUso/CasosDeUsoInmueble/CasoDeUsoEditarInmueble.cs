namespace Alquileres_Express.Aplicacion.CasosDeUso;
using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Enumerativo;
using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Aplicacion.Validadores;

public class CasoDeUsoEditarInmueble(IRepositorioInmueble repositorio, ValidadorInmueble validadorInmueble)
{
    public bool Ejecutar(Inmueble inmueble, RolUsuario rol, out string mensajeError)
    {
        mensajeError = string.Empty;
        try
        {
            validadorInmueble.Ejecutar(inmueble);

            if (repositorio.SeRepiteNombre(inmueble))
            {
                mensajeError = "Ya existe un inmueble con el mismo nombre.";
                return false;
            }
            if (rol != RolUsuario.Gerente)
            {
                mensajeError = "Solo los administradores o gerentes pueden agregar inmuebles.";
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

}
