using Alquileres_Express.Aplicacion.Entidades;

namespace Alquileres_Express.Aplicacion.Validadores;

using Alquileres_Express.Aplicacion.Enumerativo;



public class ValidadorInmueble
{
    public bool Ejecutar(Inmueble inmueble)
    {
        return ValidarCampos(inmueble);
    }

    private bool ValidarCampos(Inmueble inmueble)
    {
        if (string.IsNullOrWhiteSpace(inmueble.Nombre) || string.IsNullOrWhiteSpace(inmueble.Direccion) || string.IsNullOrWhiteSpace(inmueble.CoordLat) ||
        string.IsNullOrWhiteSpace(inmueble.CoordLong) || string.IsNullOrWhiteSpace(inmueble.Ciudad) || string.IsNullOrWhiteSpace(inmueble.CodigoPostal) ||
        inmueble.Precio == null || inmueble.Banios == null || inmueble.CantidadDeCamas == null)
            return false;

        //Verificar enumerativo
        if (!Enum.IsDefined(typeof(TipoDeInmueble), inmueble.TipoInmueble))
            return false;
        return true;
    }
}