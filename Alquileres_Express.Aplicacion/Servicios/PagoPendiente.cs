

using Alquileres_Express.Aplicacion.Entidades;

public class PagoPendiente
{
    public string IdPago { get; set; }
    public Alquiler alquiler { get; set; }

    public PagoPendiente(string idPago, Alquiler alquiler)
    {
        IdPago = idPago;
        this.alquiler = alquiler;

    }

}