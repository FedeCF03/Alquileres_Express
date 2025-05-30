using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Enumerativo;
namespace Alquileres_Express.Aplicacion.Interfaces;

public interface IRepositorioInmueble
{
    public int AgregarInmueble(Inmueble inmueble);
    public bool ModificarInmueble(Inmueble inmueble);
    public bool EliminarInmueble(int id);
    public Inmueble ObtenerInmueblePorId(int id);

    public Inmueble ObtenerInmueblePorNombre(string nombre);
    public List<Inmueble> ObtenerTodosLosInmuebles();
    public List<Inmueble> ObtenerInmueblesPorTipo(TipoDeInmueble tipo);
    public List<Inmueble> ObtenerInmueblesDisponibles();

}