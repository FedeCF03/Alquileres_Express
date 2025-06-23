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
                Correo = "gonzalo@gmail.com",
                Dni = "12312312",
                Contraseña = BCrypt.Net.BCrypt.HashPassword("123456"),
                Direccion = "Calle Falsa 123",
                FechaNacimiento = new DateTime(1990, 1, 1),
                Rol = Aplicacion.Enumerativo.RolUsuario.Empleado
                ,
            });

            Inmueble inmueble = new Inmueble
            {
                Nombre = "Casa en la playa",
                Direccion = "Avenida del Mar 123",
                CoordLat = -34.6037,
                CoordLong = -58.3816,
                Banios = 1,
                Disponible = true,
                Ciudad = "Mar del Plata",
                Precio = 800,
                CantidadDeCamas = 2,
                TipoInmueble = Aplicacion.Enumerativo.TipoDeInmueble.Vivienda
            };
            context.Add(inmueble);
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
            context.SaveChanges();

            var cliente = new Cliente
            {
                Nombre = "Lucas",
                Apellido = "Pérez",
                Correo = "prueba@gmail.com",
                Dni = "22222222",
                Contraseña = BCrypt.Net.BCrypt.HashPassword("123456"),
                Direccion = "Calle Real 456",
                FechaNacimiento = new DateTime(1995, 5, 15),
                Rol = Aplicacion.Enumerativo.RolUsuario.Cliente
            };
            context.Add(cliente);
            context.SaveChanges(); // para generar el Id

            var alquiler1 = new Alquiler
            {
                ClienteId = cliente.Id,
                CorreoCliente = cliente.Correo,
                FechaDeInicio = DateTime.Today.AddDays(-10),
                FechaDeFin = DateTime.Today.AddDays(-5),
                Precio = 5000,
                InmuebleId = 1,
                Pagado = true
            };

            var alquiler2 = new Alquiler
            {
                ClienteId = cliente.Id,
                CorreoCliente = cliente.Correo,
                FechaDeInicio = DateTime.Today.AddDays(-20),
                FechaDeFin = DateTime.Today.AddDays(-15),
                Precio = 6500,
                InmuebleId = 1,
                Pagado = true
            };

            context.Alquileres.AddRange(alquiler1, alquiler2);
            inmueble.Alquileres.Add(alquiler1);
            inmueble.Alquileres.Add(alquiler2);

            context.SaveChanges();
           
        }
        
        var connection = context.Database.GetDbConnection();
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = "PRAGMA journal_mode=DELETE;";
        command.ExecuteNonQuery();
    } 
}