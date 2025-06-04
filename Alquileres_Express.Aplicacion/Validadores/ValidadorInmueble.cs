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
        if (string.IsNullOrWhiteSpace(inmueble.Nombre) ||
        string.IsNullOrWhiteSpace(inmueble.Direccion) ||
        string.IsNullOrWhiteSpace(inmueble.Ciudad))
            return false;
        return true;
    }
}