using Alquileres_Express.Aplicacion.Enumerativo;
namespace Alquileres_Express.Aplicacion.Entidades
{
    public class Inmueble
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public string Direccion { get; set; }
        public string CoordLong { get; set; }
        public string CoordLat { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public string CodigoPostal { get; set; }
        public double Precio { get; set; }
        public int Habitaciones { get; set; }
        public int Banios { get; set; }
        public TipoDeInmueble TipoInmueble { get; set; }
        public List<Alquiler>? alquileres;
    }


}