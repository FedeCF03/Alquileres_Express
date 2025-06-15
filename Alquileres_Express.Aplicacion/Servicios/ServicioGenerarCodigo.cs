namespace Alquileres_Express.Aplicacion.Servicios;

public  class ServicioGenerarCodigo
{
    public string GenerarCodigoAleatorio()
    {
        Random random = new();
        string codigo = "";
        for (int i = 0; i < 4; i++)
        {
            int numeroAleatorio = random.Next(1, 10);
            codigo += numeroAleatorio.ToString();
        }
        return codigo;
    }
}