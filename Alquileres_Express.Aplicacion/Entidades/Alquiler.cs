namespace Alquileres_Express.Aplicacion.Entidades;

using Alquileres_Express.Aplicacion.Enumerativo;


public class Alquiler
{
    public int ClienteId { get; set; }
    public RangoDeFechas RangoDeFechas { get; set; }
    public double precio;
    public bool Cancelado { get; set; }
    public int InmuebleId { get; set; }

    public EstadoDeAlquiler GetEstadoDeAlquiler()
    {

        if (Cancelado)
            return EstadoDeAlquiler.Cancelado;

        if (RangoDeFechas.Contains(DateTime.Now)) //se puede cancelar el mismo día antes de las 3?
            return EstadoDeAlquiler.EnProceso;

        if (RangoDeFechas.StartDate > DateTime.Now)
            return EstadoDeAlquiler.Vigente;

        return EstadoDeAlquiler.Terminado;


    }





}