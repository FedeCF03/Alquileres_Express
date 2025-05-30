namespace Alquileres_Express.Aplicacion.CasosDeUso;

using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Enumerativo;
using Alquileres_Express.Aplicacion.Validadores;

public class CasoDeUsoAltaInmueble(ValidadorInmueble validador, IRepositorioInmueble repoInmueble)
{
    public ValidadorInmueble Validador { get; set; } = validador;
    public IRepositorioInmueble RepoInmueble { get; set; } = repoInmueble;
    public int Ejecutar(Inmueble inmueble, RolUsuario rolUsuario)
    {
        try
        {
            if (!Validador.Ejecutar(inmueble))
            {
                return -1;
            }
            if (rolUsuario != RolUsuario.Gerente)
                return -1;
            return RepoInmueble.AgregarInmueble(inmueble);
        }
        catch (Exception ex)
        {
            return -1;
        }
    }
}
