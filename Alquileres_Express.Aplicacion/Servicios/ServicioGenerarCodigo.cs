namespace Alquileres_Express.Aplicacion.Servicios;

public  class ServicioGenerarCodigo
{
    public string GenerarCodigoAleatorio()
    {
        Random random = new();
        String codigo = "";
        for (int i = 0; i < 4; i++)
        {
            int numeroAleatorio = random.Next(0, 10);
            codigo += numeroAleatorio.ToString();
        }
        return codigo;
    }
}