namespace Alquileres_Express.Aplicacion.CasosDeUso;

using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Aplicacion.Validadores;
using Alquileres_Express.Aplicacion.Entidades;

public class CasoDeUsoCargarInmueble(IRepositorioInmueble repo, ValidadorInmueble validador) : CasoDeUsoInmueble(repo)
{
    public bool Ejecutar(Inmueble inmueble)
    {
        if (!validador.Ejecutar(inmueble))
            return false;
        return repo.AgregarInmueble(inmueble);

    }

}

