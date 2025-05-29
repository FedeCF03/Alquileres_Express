using Alquileres_Express.Aplicacion.Entidades;
namespace Alquileres_Express.Aplicacion.Interfaces;

public interface IRepositorioInmueble
{
    public bool AgregarInmueble(Inmueble inmueble);
    public bool ModificarInmueble(Inmueble inmueble);
    public bool EliminarInmueble(int id);
    public Inmueble ObtenerInmueblePorId(int id);

    public List<Inmueble> ObtenerInmueblePorNombre(string nombre);
    public List<Inmueble> ObtenerTodosLosInmuebles();
    public List<Inmueble> ObtenerInmueblesPorTipo(string tipo);
    public List<Inmueble> ObtenerInmueblesPorUbicacion(string ubicacion);
    public List<Inmueble> ObtenerInmueblesDisponibles();

}