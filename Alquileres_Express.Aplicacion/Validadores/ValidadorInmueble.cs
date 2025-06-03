using Alquileres_Express.Aplicacion.Entidades;

namespace Alquileres_Express.Aplicacion.Validadores;

using Alquileres_Express.Aplicacion.Enumerativo;



public class ValidadorInmueble
{
    public void Ejecutar(Inmueble inmueble)
    {
        CamposEstanVacios(inmueble);
        ValoresSonValidos(inmueble);
        UbicacionEsValida(inmueble);
    }

    private void CamposEstanVacios(Inmueble inmueble)
    {
        if (string.IsNullOrWhiteSpace(inmueble.Nombre))
            throw new Exception("El nombre del inmueble no puede estar vacío.");
        if (string.IsNullOrWhiteSpace(inmueble.Direccion))
            throw new Exception("La dirección del inmueble no puede estar vacía.");
        if (string.IsNullOrWhiteSpace(inmueble.Ciudad))
            throw new Exception("La ciudad del inmueble no puede estar vacía.");
        if (inmueble.Precio == null)
            throw new Exception("El precio del inmueble no puede estar vacío.");
        if (inmueble.CantidadDeCamas == null)
            throw new Exception("La cantidad de camas del inmueble no puede estar vacía.");
        if (inmueble.Banios == null)
            throw new Exception("La cantidad de baños del inmueble no puede estar vacía.");  
    }
    private void ValoresSonValidos(Inmueble inmueble)
    {
        if (inmueble.Precio <= 0)
            throw new Exception("El precio del inmueble debe ser mayor o igual a 0.");
        if (inmueble.CantidadDeCamas <= 0)
            throw new Exception("La cantidad de camas del inmueble debe ser mayor o igual a 0.");
        if (inmueble.Banios <= 0)
            throw new Exception("La cantidad de baños del inmueble debe ser mayor o igual a 0.");
    }

    private void UbicacionEsValida(Inmueble inmueble)
    {
        if (inmueble.CoordLat == 0 && inmueble.CoordLong == 0)
            throw new Exception("Por favor, ingresa una ubicación para el inmueble.");
    }
}