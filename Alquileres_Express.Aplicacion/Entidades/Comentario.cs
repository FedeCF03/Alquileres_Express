using Alquileres_Express.Aplicacion.Enumerativo;

namespace Alquileres_Express.Aplicacion.Entidades;

public class Comentario
{
    public string Texto { get; set; } = "";
    public DateTime Fecha { get; set; }
    public int Id { get; set; }
    public int? PersonalId { get; set; }
    public int? ClienteId { get; set; }
    public int InmuebleId { get; set; }
    public string NombreUsuario { get; set; } = "";
    public int? ComentarioId { get; set; } // comentario padre
    public List<Comentario> Respuestas { get; set; } = [];
    public RolUsuario RolUsuario { get; set; }

    
}