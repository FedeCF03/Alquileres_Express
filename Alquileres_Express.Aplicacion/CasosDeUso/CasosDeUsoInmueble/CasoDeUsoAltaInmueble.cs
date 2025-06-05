namespace Alquileres_Express.Aplicacion.CasosDeUso;

using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Enumerativo;
using Alquileres_Express.Aplicacion.Validadores;

public class CasoDeUsoAltaInmueble(ValidadorInmueble validador, IRepositorioInmueble repoInmueble)
{
    public ValidadorInmueble Validador { get; set; } = validador;
    public IRepositorioInmueble RepoInmueble { get; set; } = repoInmueble;
    public int Ejecutar(Inmueble inmueble, RolUsuario rolUsuario, out string mensajeError)
    {
        mensajeError = string.Empty;
        try
        {
            Validador.Ejecutar(inmueble);
            if (RepoInmueble.SeRepiteNombre(inmueble))
            {
                mensajeError = "Ya existe un inmueble con el mismo nombre.";
                return -1;
            }
            if (rolUsuario != RolUsuario.Gerente)
            {
                mensajeError = "Solo los administradores o gerentes pueden agregar inmuebles.";
                return -1;
            }
            return RepoInmueble.AgregarInmueble(inmueble);
        }
        catch (Exception ex)
        {
            mensajeError = ex.Message;
            return -1;
        }
    }
}
