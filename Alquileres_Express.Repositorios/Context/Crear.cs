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
                    Correo = "tomicarp12@gmail.com",
                    Contraseña = BCrypt.Net.BCrypt.HashPassword("123456"),
                    Direccion = "Calle Falsa 123",
                    FechaNacimiento = new DateTime(1990, 1, 1),
                    Rol = Aplicacion.Enumerativo.RolUsuario.Administrador,
                });
                context.Add( new Inmueble
                {
                    Nombre = "Departamento en la playa",
                    Direccion = "Avenida del Mar 123",
                    CoordLat = -34.6037,
                    CoordLong = -58.3816,
                    Banios = 1,
                    Disponible = true,
                    Ciudad = "Mar del Plata",
                    Precio = 800,
                    CantidadDeCamas = 2,
                    TipoInmueble = Aplicacion.Enumerativo.TipoDeInmueble.Vivienda
                });
                context.SaveChanges();
                context.Add(new Foto
                {
                    Url = "/images/fotosInmuebles/0com0pnv.png",
                    InmuebleId = 1
                });
                context.Add(new Foto
                {
                    Url = "/images/fotosInmuebles/3p43bsam.png",
                    InmuebleId = 1
                });
                context.Add(new Inmueble
                {
                    Nombre = "Casa en la montaña",
                    Direccion = "Calle de la Montaña 456",
                    CoordLat = -34.6037,
                    CoordLong = -58.3816,
                    Banios = 2,
                    Disponible = true,
                    Ciudad = "Bariloche",
                    Precio = 1200,
                    CantidadDeCamas = 4,
                    TipoInmueble = Aplicacion.Enumerativo.TipoDeInmueble.Vivienda
                });
                context.SaveChanges();
                context.Add(new Foto
                {
                    Url = "/images/fotosInmuebles/05gvcetk.png",
                    InmuebleId = 2
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