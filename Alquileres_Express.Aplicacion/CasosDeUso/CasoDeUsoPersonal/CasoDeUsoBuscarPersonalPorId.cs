namespace Alquileres_Express.Aplicacion.CasosDeUso;
using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;

public class CasoDeUsoBuscarPersonalPorId(IRepositorioPersonal repositorio) : CasoDeUsoPersonal(repositorio)
{
    public Personal? Ejecutar(int id)
    {
        try
        {
            return Repositorio.ObtenerPersonalPorId(id);

        }
        catch (Exception ex)
        {
            return null;
        }
    }
}