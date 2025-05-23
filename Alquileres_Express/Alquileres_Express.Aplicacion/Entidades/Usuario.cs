using System;

namespace Alquileres_Express.Aplicacion.Entidades;

public abstract class Usuario
{
    public int ID { get; set; }
    public string Correo { get; set; }
    public string Contraseña { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Direccion { get; set; }
    public DateTime FechaNacimiento { get; set; }

    public RolUsuario Rol { get; set; }

    // Constructor de la clase base
    public Usuario(int id, string correo, string contraseña, string nombre, string apellido, string direccion, DateTime fechaNacimiento)
    {
        ID = id;
        Correo = correo;
        Contraseña = contraseña;
        Nombre = nombre;
        Apellido = apellido;
        Direccion = direccion;
        FechaNacimiento = fechaNacimiento;
    }
    public Usuario()
    {

    }
}
