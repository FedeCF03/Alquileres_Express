namespace Alquileres_Express.Repositorios.Context;

using Alquileres_Express.Aplicacion.Entidades;
using Microsoft.EntityFrameworkCore;

public class Crear
{
    public static void Inicializar()
    {
        
        try
        {
            using var context = new Alquileres_ExpressContext();
            if (context.Database.EnsureCreated())
            {
                Console.WriteLine("Base de datos creada exitosamente.");
                context.Add(new Personal
                {
                    Nombre = "María",
                    Apellido = "Torres",
                    Correo = "tomicarp12@gmail.com",
                    Contraseña = BCrypt.Net.BCrypt.HashPassword("123456"),
                    Direccion = "Calle Falsa 123",
                    FechaNacimiento = new DateTime(1990, 1, 1),
                    Rol = Aplicacion.Enumerativo.RolUsuario.Administrador,
                });
                context.SaveChanges();
            }
                var connection = context.Database.GetDbConnection();
                connection.Open();
                using var command = connection.CreateCommand();
                command.CommandText = "PRAGMA journal_mode=DELETE;";
                command.ExecuteNonQuery();

            
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al inicializar la base de datos: {ex.Message}");
        }
    }
}