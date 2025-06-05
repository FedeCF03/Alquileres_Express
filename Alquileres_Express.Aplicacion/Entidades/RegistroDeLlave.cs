namespace Alquileres_Express.Aplicacion.Entidades;
public class RegistroDeLlave
{
    public int Id { get; set; }
    public int AlquilerId { get; set; }
    public int PersonalId { get; set; }
    public DateTime FechayHoraRegistro { get; set; }
    public int ClienteId { get; set; }
    public bool EsEntega { get; set; }
}
