// namespace Alquileres_Express.Repositorios.RepositoriosSQLite;
// using Alquileres_Express.Aplicacion.Entidades;
// using Alquileres_Express.Aplicacion.Interfaces;
// using Alquileres_Express.Aplicacion.Validadores;
// using Alquileres_Express.Repositorios.Context;
// using System.Collections.Generic;




<<<<<<< HEAD


}
=======
// public class RepositorioUsuarioGenerico<T> : IRepositorioGenerico
// {
//     readonly Alquileres_ExpressContext _context;


//     public List<Usuario> Listar<T>()
//     {
//         return [.. _context.Set<T>()];
//     }


//     public void Registrar<T>(T u) where T : Usuario
//     {
//         ValidadorUsuario validador = new ();
//         validador.Ejecutar(u);
//         //validar mail
//         if (!_context.Set<Usuario>().Any(user => user.Correo.Equals(u.Correo)))
//         {
//             u.Contraseña = BCrypt.Net.BCrypt.HashPassword(u.Contraseña.Trim());//.trim() elimina espacios en blanco
//             _context.Set<T>().Add(u);
//             _context.SaveChanges();
//         }
//         else
//         {
//             throw new InvalidOperationException("El correo ya está registrado por otro usuario.");
//         }
//     }

// }
>>>>>>> 1e1dc5b20dcd63fded11f935519ac8e11e4d44f2
