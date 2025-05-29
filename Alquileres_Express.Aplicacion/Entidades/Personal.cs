namespace Alquileres_Express.Aplicacion.Entidades;

public class Personal : Usuario
{
    public int NumeroPersonal { get; set; }
    public int CodigoDeSeguridad { get; set; }

    public Personal() : base()
    {

    }


}
