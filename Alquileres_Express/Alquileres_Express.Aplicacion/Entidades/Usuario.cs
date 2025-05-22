using System;

namespace Alquileres_Express.Aplicacion.Entidades;

public class Usuario
{
    public int ID { get; set; }
    public String correo { get; set; }
    public String contraseña { get; set; }
    public String nombre { get; set; }
    public String apellido { get; set; }
    public String direccion { get; set; }
    public DateTime fechaNacimiento { get; set; }

}