namespace Alquileres_Express.Aplicacion.CasosDeUso;

using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Enumerativo;
using Alquileres_Express.Aplicacion.Validadores;

public class CasoDeUsoAltaInmueble(ValidadorInmueble validador, IRepositorioInmueble repoInmueble)
{
    public ValidadorInmueble Validador { get; set; } = validador;
    public IRepositorioInmueble RepoInmueble { get; set; } = repoInmueble;
    public int Ejecutar(Inmueble inmueble, RolUsuario rolUsuario, out List<string> errores)
    {
        if (rolUsuario != RolUsuario.Gerente)
        {
            errores = [];
            errores.Add("Solo los gerentes pueden agregar inmuebles.");
            return -1;
        }
        errores = Validador.Ejecutar(inmueble);
        if (errores.Count > 0)
        {
            return -1;
        }
        if (inmueble.Nombre != null && RepoInmueble.SeRepiteNombre(inmueble))
        {
            errores.Add("Ya existe un inmueble con el mismo nombre.");
            return -1;
        }
        try
        {
            return RepoInmueble.AgregarInmueble(inmueble);
        }
        catch (Exception ex)
        {
            errores.Add($"Error al agregar el inmueble: {ex.Message}");
            return -1;
        }
    }
}
