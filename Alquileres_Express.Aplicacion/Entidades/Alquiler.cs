namespace Alquileres_Express.Aplicacion.Entidades;

public class Alquiler
{
    public int Id { get; set; }
    public Cliente Cliente { get; set; }
    public RangoDeFechas RangoDeFechas { get; set; }
    public double precio;
    public bool Cancelado { get; set; }
    public Inmueble Inmueble { get; set; }


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