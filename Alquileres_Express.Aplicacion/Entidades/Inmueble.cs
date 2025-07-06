using Alquileres_Express.Aplicacion.Enumerativo;
using System.ComponentModel.DataAnnotations;

namespace Alquileres_Express.Aplicacion.Entidades;

    public class Inmueble
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public string? Direccion { get; set; }
        public double CoordLong { get; set; }
        public double CoordLat { get; set; }
        public bool Borrado { get; set; } = false;

        public string? Ciudad { get; set; }
        public decimal Precio { get; set; }
        public int CantidadDeCamas { get; set; }//Se refiere a cantidad de personas 
        public int CantidadDeHabitaciones { get; set; }
        public int Banios { get; set; }
        public TipoDeInmueble TipoInmueble { get; set; } = TipoDeInmueble.Vivienda;
        public PoliticaDeCancelacion PoliticaDeCancelacion { get; set; } = PoliticaDeCancelacion.SinCosto;
        public bool Disponible { get; set; }
        public List<Foto>? Fotos { get; set; } = [];
        public List<Alquiler>? Alquileres { get; set; } = [];
        public List<Comentario>? Comentarios { get; set; } = [];
        public List<Valoracion>? Valoraciones { get; set; } = new List<Valoracion>();
        public double PromedioCalificacion { get; set; }

        public override bool Equals(object? obj)
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


        public Inmueble()
        {
        }


    
    }
