using Alquileres_Express.Aplicacion.Entidades;
namespace Alquileres_Express.Aplicacion.Validadores;



public class ValidadorInmueble
{
    private List<string>  _errores = [];
    public List<string> Ejecutar(Inmueble inmueble)
    {
        CamposEstanVacios(inmueble);
        ValoresSonValidos(inmueble);
        UbicacionEsValida(inmueble);
        return _errores;
    }

    private void CamposEstanVacios(Inmueble inmueble)
    {
        if (string.IsNullOrWhiteSpace(inmueble.Nombre))
            _errores.Add("El nombre del inmueble no puede estar vacío.");
        if (string.IsNullOrWhiteSpace(inmueble.Direccion))
            _errores.Add("La dirección del inmueble no puede estar vacía.");
        if (string.IsNullOrWhiteSpace(inmueble.Ciudad))
            _errores.Add("La ciudad del inmueble no puede estar vacía.");
    }
    private void ValoresSonValidos(Inmueble inmueble)
    {
        if (inmueble.Precio <= 0)
            _errores.Add("El precio del inmueble debe ser mayor a 0.");
        if (inmueble.CantidadDeCamas < 0)
            _errores.Add("La cantidad de camas del inmueble debe ser mayor o igual a 0.");
        if (inmueble.CantidadDeHabitaciones < 0)
            _errores.Add("La cantidad de habitaciones del inmueble debe ser mayor o igual a 0.");
        if (inmueble.Banios < 0)
            _errores.Add("La cantidad de baños del inmueble debe ser mayor o igual a 0.");
    }

    private void UbicacionEsValida(Inmueble inmueble)
    {
        if (inmueble.CoordLat == 0 && inmueble.CoordLong == 0)
           _errores.Add("Por favor, ingresa una ubicación para el inmueble.");
    }
}