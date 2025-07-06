namespace Alquileres_Express.Aplicacion.Entidades;

using Alquileres_Express.Aplicacion.Enumerativo;
using Alquileres_Express.Aplicacion.CasosDeUso;

public class Alquiler
{
    public int Id { get; set; }
    public string CorreoCliente { get; set; } //Cambiar por id
    public int ClienteId { get; set; } 
    public DateTime FechaDeCreacion { get; set; } 
    public DateTime FechaDeInicio { get; set; }
    public DateTime FechaDeFin { get; set; }
    public decimal Precio { get; set; }
    public bool Cancelado { get; set; } = false;
    public int InmuebleId { get; set; }
    public string? NombreDePersonal { get; set; }
    public string? ApellidoDePersonal { get; set; }
    public List<RegistroDeLlave>? RegistrosDeLlave { get; set; }
    public bool Pagado { get; set; } = false;



    public Alquiler() { }

    public Alquiler(string correoCLiente, DateTime fechaDeInicio, DateTime fechaDeFin, decimal precio, int idInmueble)
    {
        CorreoCliente = correoCLiente;
        InmuebleId = idInmueble;
        FechaDeInicio = fechaDeInicio;
        FechaDeFin = fechaDeFin;
        Precio = precio;//Lo creo en null y despues lo agrego
        Cancelado = false;  // Por defecto, un alquiler recién creado no está cancelado.
        Pagado = false;
    }

    public Alquiler(string correoCLiente, DateTime fechaInicio, DateTime fechaFin, decimal precio, int idInmueble, string nombreDePersonal, string apellidoDePersonal)
    {
        CorreoCliente = correoCLiente;
        InmuebleId = idInmueble;
        FechaDeInicio = fechaInicio;
        FechaDeFin = fechaFin;
        Precio = precio;
        NombreDePersonal = nombreDePersonal;
        ApellidoDePersonal = apellidoDePersonal;
        Cancelado = false;  // Por defecto, un alquiler recién creado no está cancelado.
        Pagado = false;
    }
    public EstadoDeAlquiler GetEstadoDeAlquiler()
    {
        DateTime fechaDeHoy = DateTime.Today.AddHours(12);
        DateTime horaLimite = FechaDeInicio.AddHours(14); 
        if ((FechaDeInicio <= DateTime.Today  || (FechaDeInicio == DateTime.Today && DateTime.Now.Hour > 14)) && FechaDeFin >= DateTime.Today) //se puede cancelar el mismo día antes de las 3?
            return EstadoDeAlquiler.EnProceso;

        if (FechaDeInicio > DateTime.Today)
            return EstadoDeAlquiler.Vigente;//Vigente se refiere a que el alquiler está activo y aún no ha comenzado.

        return EstadoDeAlquiler.Terminado;
    }

}