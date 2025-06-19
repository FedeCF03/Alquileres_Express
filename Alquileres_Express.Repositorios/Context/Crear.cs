namespace Alquileres_Express.Repositorios.Context;

using Alquileres_Express.Aplicacion.Entidades;
using Microsoft.EntityFrameworkCore;

public class Crear
{
    public static void Inicializar()
    {
        using var context = new Alquileres_ExpressContext();
        if (context.Database.EnsureCreated())
        {
            Console.WriteLine("Base de datos creada exitosamente.");
            context.Add(new Personal
            {
                Nombre = "María",
                Apellido = "Torres",
                Correo = "marfacucosas@gmail.com",
                Dni = "11111111",
                Contraseña = BCrypt.Net.BCrypt.HashPassword("123456"),
                Direccion = "Calle Falsa 123",
                FechaNacimiento = new DateTime(1990, 1, 1),
                Rol = Aplicacion.Enumerativo.RolUsuario.Gerente,
            });
            context.Add(new Personal
            {
                Nombre = "Mario",
                Apellido = "Castro",
                Correo = "castrotomasandres05@gmail.com",
                Dni = "12312312",
                Contraseña = BCrypt.Net.BCrypt.HashPassword("123456"),
                Direccion = "Calle Falsa 123",
                FechaNacimiento = new DateTime(1990, 1, 1),
                Rol = Aplicacion.Enumerativo.RolUsuario.Empleado
                ,
            });
            context.SaveChanges();
           
        }
        
        var connection = context.Database.GetDbConnection();
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = "PRAGMA journal_mode=DELETE;";
        command.ExecuteNonQuery();
    } 
}