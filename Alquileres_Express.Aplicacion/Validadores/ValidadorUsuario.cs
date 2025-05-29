using Alquileres_Express.Aplicacion.Entidades;
using RestSharp.Extensions;

namespace Alquileres_Express.Aplicacion.Validadores;

public class ValidadorUsuario
{
    public void Ejecutar(Usuario usuario)
    {
        ValidarCampos(usuario);
        ValidarContraseña(usuario.Contraseña);
        ValidarEdad(usuario.FechaNacimiento);
    }

    private void ValidarCampos(Usuario u)
    {
        if (string.IsNullOrWhiteSpace(u.Nombre))
            throw new InvalidOperationException("El nombre no puede estar vacío.");
        if (string.IsNullOrWhiteSpace(u.Apellido))
            throw new InvalidOperationException("El apellido no puede estar vacío.");
        if (string.IsNullOrWhiteSpace(u.Correo))
            throw new InvalidOperationException("El correo no puede estar vacío.");
        u.Correo = u.Correo.ToLower();//Paso el correo todo a minuscula
        if (!u.Correo.Contains("@") || !u.Correo.Contains(".com"))
            throw new InvalidOperationException("El correo ingresado no es válido.");
        if (string.IsNullOrWhiteSpace(u.Contraseña))
            throw new InvalidOperationException("La contraseña no puede estar vacía.");
        if (string.IsNullOrWhiteSpace(u.Direccion))
            throw new InvalidOperationException("La dirección no puede estar vacía.");
    }

    private void ValidarContraseña(string contraseña)
    {
        if (contraseña.Length < 6)
            throw new InvalidOperationException("La contraseña debe tener al menos 6 caracteres.");
    }

    private void ValidarEdad(DateTime fechaNacimiento)
    {
        TimeSpan diferencia = DateTime.Now - fechaNacimiento;
        if (diferencia.TotalDays < 6570) // 6570 días = 18 años
            throw new InvalidOperationException("El usuario debe ser mayor de edad.");
    }
}
