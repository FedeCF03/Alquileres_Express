namespace Alquileres_Express.Aplicacion.Entidades
{
    public class Foto
    {
        public int Id { get; set; }
        public string Url { get; set; } = "";
        public string Nombre { get; set; } = "";
        public int InmuebleId { get; set; }

    }
}