namespace Alquileres_Express.Aplicacion.CasosDeUso;

using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Aplicacion.Entidades;
public class CasoDeUsoObtenerIngresosDeInmueble(IRepositorioInmueble repo) : CasoDeUsoInmueble(repo)
{
    public decimal Ejecutar(int id)
    {
        return repo.obtenerIngresosDeInmueble(id);
    }
}