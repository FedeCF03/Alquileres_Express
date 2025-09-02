namespace Alquileres_Express.Aplicacion.CasosDeUso;

using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Aplicacion.Entidades;
public class CasoDeUsoListarInmuebles(IRepositorioInmueble repo) : CasoDeUsoInmueble(repo)
{
    public List<Inmueble> ListarDisponibles()
    {
        return repo.ObtenerInmueblesDisponibles();
    }
    public List<Inmueble> ListarTodos()
    {
        return repo.ObtenerTodosLosInmuebles();
    }

    public List<Inmueble> ListarNoDisponibles()
    {
        return repo.ObtenerLosInmueblesNoDisponibles();
    }
}