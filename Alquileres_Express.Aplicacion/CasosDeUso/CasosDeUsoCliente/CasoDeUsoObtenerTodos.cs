using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;

namespace Alquileres_Express.Aplicacion.CasosDeUso;

 public class CasoDeUsoObtenerTodos(IRepositorioCliente repositorio) : CasoDeUsoCliente(repositorio)
 {
    public List<Cliente> Ejecutar()
    {
        try
        {
            return Repositorio.ObtenerClientes();

        }
        catch (Exception ex)
        {
            return null;
        }
    }
 }