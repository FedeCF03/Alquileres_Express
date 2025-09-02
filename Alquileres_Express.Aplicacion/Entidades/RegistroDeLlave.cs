namespace Alquileres_Express.Aplicacion.Entidades;

public class RegistroDeLlave(int alquilerId, int personalId, int clienteId, bool esEntrega)
{
    public int AlquilerId { get; set; } = alquilerId;
    public int PersonalId { get; set; } = personalId;
    public DateTime FechayHoraRegistro { get; set; } = DateTime.Now;
    public int ClienteId { get; set; } = clienteId;
    public bool EsEntrega { get; set; } = esEntrega;

}
