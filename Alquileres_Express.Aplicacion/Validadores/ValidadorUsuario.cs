using System.Text.RegularExpressions;
using Alquileres_Express.Aplicacion.Entidades;
using RestSharp.Extensions;

namespace Alquileres_Express.Aplicacion.Validadores;

public class ValidadorUsuario
{
    private List<string> _errores = [];
    public List<string> Ejecutar(Usuario usuario)
    {
        _errores.Clear();
        ValidarCampos(usuario);
        ValidarEdad(usuario.FechaNacimiento);
        return _errores;
    }

    private void ValidarCampos(Usuario u)
    {
        if (string.IsNullOrWhiteSpace(u.Nombre))
            _errores.Add("El nombre no puede estar vacío.");
        if (string.IsNullOrWhiteSpace(u.Dni))
            _errores.Add("El DNI no puede estar vacío.");
        else
            ValidarDni(u.Dni);
        if (string.IsNullOrWhiteSpace(u.Apellido))
            _errores.Add("El apellido no puede estar vacío.");
        if (string.IsNullOrWhiteSpace(u.Correo))
            _errores.Add("El correo no puede estar vacío.");
        else
            if (!u.Correo.Contains('@'))
            _errores.Add("El correo ingresado no es válido.");
            else
                u.Correo = u.Correo.ToLower();
        
        if (string.IsNullOrWhiteSpace(u.Contraseña))
            _errores.Add("La contraseña no puede estar vacía.");
        else
            ValidarContraseña(u.Contraseña);
        if (string.IsNullOrWhiteSpace(u.Direccion))
            _errores.Add("La dirección no puede estar vacía.");
    }

    private void ValidarContraseña(string contraseña)
    {
        if (contraseña.Length < 6)
            _errores.Add("La contraseña debe tener al menos 6 caracteres.");
    }

    private void ValidarEdad(DateTime fechaNacimiento)
    {
        int edad = DateTime.Today.Year - fechaNacimiento.Year;
        if (fechaNacimiento > DateTime.Today.AddYears(-edad))
            edad--;
        if (edad < 18)
            _errores.Add("El usuario debe ser mayor de edad.");
    }

    private void ValidarDni(string dni)
    {
        if (!Regex.IsMatch(dni, @"^\d{7,8}$"))
           _errores.Add("El DNI debe tener entre 7 y 8 dígitos.");
    }

}
