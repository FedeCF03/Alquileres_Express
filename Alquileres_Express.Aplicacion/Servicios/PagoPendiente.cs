

using Alquileres_Express.Aplicacion.Entidades;

public class PagoPendiente(string idPago, Alquiler alquiler)
{
    public string IdPago { get; set; } = idPago;
    public Alquiler alquiler { get; set; } = alquiler;
}