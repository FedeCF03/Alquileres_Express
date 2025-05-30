namespace Alquileres_Express.Aplicacion.CasosDeUso;

using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Aplicacion.Entidades;
public class CasoDeUsoListarInmuebles(IRepositorioInmueble repo) : CasoDeUsoInmueble(repo)
{
    public List<Inmueble> Ejecutar()
    {
        return repo.ObtenerInmueblesDisponibles();
    }
}