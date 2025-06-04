namespace Alquileres_Express.Aplicacion.Entidades;

public class RegistroDeLlave
{
    public int Id { get; set; }
    public Inmueble? Inmueble { get; set; }
    public Alquiler? Alquiler { get; set; }
    public Personal? PersonalEntrega { get; set; }
    public Personal? PersonalDevolucion { get; set; }
    public DateTime FechayHoraRegistro { get; set; }
    public Cliente? Cliente { get; set; }
    public DateTime FechaDevolucion { get; set; }
}