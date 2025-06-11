using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;

namespace Alquileres_Express.Aplicacion.CasosDeUso;

 public class CasoDeUsoBuscarClientePorId(IRepositorioCliente repositorio) : CasoDeUsoCliente(repositorio)
 {
    public Cliente? Ejecutar(int id)
    {
        try
        {
            return Repositorio.ObtenerClientePorId(id);

        }
        catch (Exception ex)
        {
            return null;
        }
    }
 }