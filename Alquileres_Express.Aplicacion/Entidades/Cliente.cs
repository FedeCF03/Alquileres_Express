using Alquileres_Express.Aplicacion.Enumerativo;

namespace Alquileres_Express.Aplicacion.Entidades;

public class Cliente : Usuario
{
    public List<Alquiler>? Alquileres { get; set; }
    // public List<Comentario>? Comentarios;
    // public List<Valoracion>? Valoraciones;



    // // Constructor de la clase hija que llama al constructor de Usuario
    // public Cliente(int id, string correo, string contraseña, string nombre, string apellido, string direccion, DateTime fechaNacimiento)
    //     : base(id, correo, contraseña, nombre, apellido, direccion, fechaNacimiento)
    // {
    //     Alquileres = new List<Alquiler>();
    //     this.Rol = RolUsuario.Cliente;
    // }
    public Cliente()
    {

    }
    public Cliente(int id, string dni, string correo, string contraseña, string nombre, string apellido, string direccion, DateTime fechaNacimiento, RolUsuario rol)
        : base(id, dni, correo, contraseña, nombre, apellido, direccion, fechaNacimiento, rol)
    {
       
    }
    
}
