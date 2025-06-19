namespace Alquileres_Express.Aplicacion.Entidades;

public class Valoracion
{
    public int Id { get; set; }           
    public int InmuebleId { get; set; }   // FK
    public int ClienteId  { get; set; }
    public int Calificacion { get; set; }
    public string? Comentario { get; set; }
    public string? NombreCliente  { get; set; }
    public string? ApellidoCliente{ get; set; }
}
