namespace Alquileres_Express.Aplicacion.CasosDeUso;

using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Enumerativo;

public class CasoDeUsoAltaInmueble(IRepositorioInmueble repoInmueble)
{
    public IRepositorioInmueble RepoInmueble { get; set; } = repoInmueble;

    public bool Ejecutar(Inmueble inmueble, RolUsuario rolUsuario)
    {
        if (rolUsuario != RolUsuario.Gerente)
            return false;
        return RepoInmueble.AgregarInmueble(inmueble);
    }
}
