namespace Alquileres_Express.Aplicacion.CasosDeUso;

using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;

public class CasoDeUsoObtenerInmueble(IRepositorioInmueble repo)
{
    public Inmueble Ejecutar(int id)
    {
        var inmueble = repo.ObtenerInmueblePorId(id) ?? throw new KeyNotFoundException($"No se encontró un inmueble con el ID {id}");
        return inmueble;
    }
}