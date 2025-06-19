namespace Alquileres_Express.Aplicacion.Entidades;

public class Valoracion
{
    public int InmuebleId { get; set; }
    public int ClienteId { get; set; }
    public int Calificacion { get; set; }
    public string? Comentario { get; set; }

    public String? NombreCliente { get; set; }

    public String? ApellidoCliente { get; set; }
}