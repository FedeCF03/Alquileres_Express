using Alquileres_Express.Aplicacion.Entidades;

namespace Alquileres_Express.Aplicacion.Validadores;

public class ValidadorUsuario
{
    public void Ejecutar(Usuario usuario)
    {
        //Validar campos
        validarCampos(usuario);
        //Validar contraseña
        if (usuario.Contraseña.Length < 6)
            throw new InvalidOperationException("La contraseña debe tener 6 o más dígitos.");

        //Validar edad
        var today = DateTime.Today;
        int edad = today.Year - usuario.FechaNacimiento.Year;
        if (usuario.FechaNacimiento > today.AddYears(-edad))
            edad--;
        if (edad < 18)
            throw new InvalidOperationException("El usuario debe ser mayor de edad.");

    }

    private void validarCampos(Usuario u)
    {
        if (string.IsNullOrWhiteSpace(u.Nombre))
            throw new InvalidOperationException("El nombre es obligatorio.");
        if (string.IsNullOrWhiteSpace(u.Apellido))
            throw new InvalidOperationException("El apellido es obligatorio.");
        if (string.IsNullOrWhiteSpace(u.Correo))
            throw new InvalidOperationException("El correo es obligatorio.");
        if (string.IsNullOrWhiteSpace(u.Contraseña))
            throw new InvalidOperationException("La contraseña es obligatoria.");
        if (string.IsNullOrWhiteSpace(u.Direccion))
            throw new InvalidOperationException("La dirección es obligatoria.");
    }
}
