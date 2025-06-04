using System;
using Alquileres_Express.Aplicacion.Enumerativo;
namespace Alquileres_Express.Aplicacion.Entidades;

public class Inmueble
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Direccion { get; set; }
    public double CoordLong { get; set; }
    public double CoordLat { get; set; }
    public string? Ciudad { get; set; }
    public double Precio { get; set; }
    public int CantidadDeCamas { get; set; }//Cantidad habitaciones
    public int Banios { get; set; }
    public TipoDeInmueble TipoInmueble { get; set; }
    public List<Alquiler>? Alquileres;
    public bool Disponible { get; set; }
    public List<Foto>? Fotos { get; set; }

    public Inmueble()
    {
        Alquileres = new List<Alquiler>();
        Fotos = new List<Foto>();
    }
    public bool Equals(object? obj)
    {
        if (obj == null)
        {
            return false;
        }
        if (obj is Inmueble inmueble)
        {
            return Id == inmueble.Id;
        }
        return false;
    }
}
