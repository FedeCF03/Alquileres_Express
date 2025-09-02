using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;

namespace Alquileres_Express.Aplicacion.CasosDeUso;

 public class CasoDeUsoObtenerCantidadDeClientesEntreFechas(IRepositorioCliente repositorio) : CasoDeUsoCliente(repositorio)
 {
    public int Ejecutar(DateTime fechaInicio, DateTime fechaFin)
    {
        try
        {
            return Repositorio.ObtenerCantidadDeClientesEntreFechas(fechaInicio, fechaFin);

        }
        catch (Exception ex)
        {
            return 0;
        }
    }
 }