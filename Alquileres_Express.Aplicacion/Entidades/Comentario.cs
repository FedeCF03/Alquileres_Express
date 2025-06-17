namespace Alquileres_Express.Aplicacion.Entidades;

public class Comentario
{
    public string Texto { get; set; } = "";
    public DateTime Fecha { get; set; }
    public int Id { get; set; }
    public int? PersonalId { get; set; }
    public int? ClienteId { get; set; }
    public int InmuebleId { get; set; }

    
}