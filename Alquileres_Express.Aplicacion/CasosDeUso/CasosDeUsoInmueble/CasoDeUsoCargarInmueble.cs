namespace Alquileres_Express.Aplicacion.CasosDeUso;

using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Aplicacion.Validadores;
using Alquileres_Express.Aplicacion.Entidades;

public class CasoDeUsoCargarInmueble(IRepositorioInmueble repo, ValidadorInmueble validador) : CasoDeUsoInmueble(repo)
{
    public int Ejecutar(Inmueble inmueble)
    {
        if (!validador.Ejecutar(inmueble))
            return -1;
        return repo.AgregarInmueble(inmueble);

    }

}

