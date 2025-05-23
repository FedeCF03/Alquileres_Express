namespace Alquileres_Express.Aplicacion.CasosDeUso;

using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Aplicacion.Entidades;

public class CasoDeUsoAltaInmueble(IRepositorioInmueble repoInmueble)
{
    public IRepositorioInmueble RepoInmueble { get; set; } = repoInmueble;

    public bool Ejecutar(Inmueble inmueble)
    {
        return RepoInmueble.AgregarInmueble(inmueble);
    }
}
