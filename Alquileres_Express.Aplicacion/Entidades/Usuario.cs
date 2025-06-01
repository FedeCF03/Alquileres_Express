namespace Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Enumerativo;

public abstract class Usuario
{
    public int Id { get; set; }
    public string Dni { get; set; } = "";
    public string Correo { get; set; } = "";

    public string Contraseña { get; set; } = "";
    public string Nombre { get; set; } = "";
    public string Apellido { get; set; } = "";
    public string Direccion { get; set; } = "";
    public DateTime FechaNacimiento { get; set; } 

    public RolUsuario Rol { get; set; } 

    public Usuario()
    {

    }
    
    // Constructor de la clase base
    // public Usuario(int id, string correo, string contraseña, string nombre, string apellido, string direccion, DateTime fechaNacimiento)
    // {
    //     Id = id;
    //     Correo = correo;
    //     Contraseña = contraseña;
    //     Nombre = nombre;
    //     Apellido = apellido;
    //     Direccion = direccion;
    //     FechaNacimiento = fechaNacimiento;
    //}
}
