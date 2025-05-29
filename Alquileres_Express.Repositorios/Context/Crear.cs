namespace Alquileres_Express.Repositorios.Context;

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

                var connection = context.Database.GetDbConnection();
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "PRAGMA journal_mode=DELETE;";
                    command.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al inicializar la base de datos: {ex.Message}");
        }
    }
}