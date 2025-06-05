namespace Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Enumerativo;

public class Alquiler
{
    public int Id { get; set; }
    public string CorreoCliente { get; set; } //Cambiar por id
    public DateTime FechaDeInicio { get; set; }
    public DateTime FechaDeFin { get; set; }
    public decimal Precio;
    public bool Cancelado { get; set; } = false;
    public int InmuebleId { get; set; }
    public string? NombreDePersonal { get; set; } 
    public string? ApellidoDePersonal { get; set; }
    public RegistroDeLlave? Registro { get; set; }
    public bool Pagado { get; set; } = false;

    public Alquiler() { }

    public Alquiler(string correoCLiente, DateTime fechaDeInicio, DateTime fechaDeFin,  decimal precio,int idInmueble)
    {
 
        CorreoCliente = correoCLiente;
        InmuebleId = idInmueble;
        FechaDeInicio = fechaDeInicio;
        FechaDeFin = fechaDeFin;
        Precio = precio;
        //NombreDePersonal = nombreDePersonal;
        //ApellidoDePersonal = apellidoDePersonal;
        Registro = null;//Lo creo en null y despues lo agrego
        Cancelado = false;  // Por defecto, un alquiler recién creado no está cancelado.
        Pagado = false; 
    }

    public Alquiler(string correoCLiente, int idInmueble, DateTime fechaInicio, DateTime fechaFin, decimal precio, string nombreDePersonal, string apellidoDePersonal)
    {
 
        CorreoCliente = correoCLiente;
        InmuebleId = idInmueble;
        FechaDeInicio = fechaInicio;
        FechaDeFin = fechaFin;
        Precio = precio;
        NombreDePersonal = nombreDePersonal;
        ApellidoDePersonal = apellidoDePersonal;
        Registro = null;//Lo creo en null y despues lo agrego
        Cancelado = false;  // Por defecto, un alquiler recién creado no está cancelado.
        Pagado = false; 
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