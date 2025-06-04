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
    public string NombreDePersonal { get; set; } = "";
    public string ApellidoDePersonal { get; set; } = "";
    public RegistroDeLlave? Registro;

    public Alquiler() { }//Necesario

    public Alquiler(Cliente cliente, Inmueble inmueble, DateTime fechaDeInicio, DateTime fechaDeFin, double precio, string nombreDePersonal, string apellidoDePersonal)
    {
        if (fechaDeFin <= fechaDeInicio)
            throw new ArgumentException("La fecha de fin debe ser mayor que la fecha de inicio.");
        Cliente = cliente;
        Inmueble = inmueble;
        FechaDeInicio = fechaDeInicio;
        FechaDeFin = fechaDeFin;
        Precio = precio;
        NombreDePersonal = nombreDePersonal;
        ApellidoDePersonal = apellidoDePersonal;
        Registro = null;//Lo creo en null y despues lo agrego
        Cancelado = false;  // Por defecto, un alquiler recién creado no está cancelado.
    }

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