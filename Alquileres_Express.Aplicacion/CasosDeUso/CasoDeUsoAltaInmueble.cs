namespace Alquileres_Express.Aplicacion.CasosDeUso;

using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Enumerativo;
using Alquileres_Express.Aplicacion.Validadores;

public class CasoDeUsoAltaInmueble(ValidadorInmueble validador, IRepositorioInmueble repoInmueble)
{
    public ValidadorInmueble Validador { get; set; } = validador;
    public IRepositorioInmueble RepoInmueble { get; set; } = repoInmueble;
    public bool Ejecutar(Inmueble inmueble, RolUsuario rolUsuario)
    {
        try
        {
            if (!Validador.Ejecutar(inmueble))
            {
                return false; // Si la validación falla, retornamos false
            }
            if (rolUsuario != RolUsuario.Gerente)
                return false;
            return RepoInmueble.AgregarInmueble(inmueble);
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}
