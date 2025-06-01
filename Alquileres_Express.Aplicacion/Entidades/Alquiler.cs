namespace Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Enumerativo;

public class Alquiler
{
    public int Id { get; set; }
    public Cliente? Cliente { get; set; }
    public DateTime FechaDeInicio { get; set; }
    public DateTime FechaDeFin { get; set; }
    public double Precio;
    public bool Cancelado { get; set; }
    public Inmueble? Inmueble { get; set; }
    public string NombreEmpleado {get; set;} = "";
    public RegistroDeLlave? Registro;

    public EstadoDeAlquiler GetEstadoDeAlquiler()
    {


        if (Cancelado)
            return EstadoDeAlquiler.Cancelado;

        if (FechaDeInicio <= DateTime.Today && FechaDeFin >= DateTime.Today) //se puede cancelar el mismo día antes de las 3?
            return EstadoDeAlquiler.EnProceso;

        if (FechaDeInicio > DateTime.Today)
            return EstadoDeAlquiler.Vigente;

        return EstadoDeAlquiler.Terminado;
    }

}