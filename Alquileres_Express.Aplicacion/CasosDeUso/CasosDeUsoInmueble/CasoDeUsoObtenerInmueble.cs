namespace Alquileres_Express.Aplicacion.CasosDeUso;

using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;

public class CasoDeUsoObtenerInmueble(IRepositorioInmueble repo)
{
    public Inmueble Ejecutar(int id)
    {
        var inmueble = repo.ObtenerInmueblePorId(id);
        return inmueble;
    }
    public Inmueble Ejecutar(string nombre)
    {
        var inmueble = repo.ObtenerInmueblePorNombre(nombre);
        return inmueble;
    }
}