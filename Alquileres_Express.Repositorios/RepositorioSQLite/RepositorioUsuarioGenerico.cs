namespace Alquileres_Express.Repositorios.RepositoriosSQLite;
using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Aplicacion.Validadores;
using Alquileres_Express.Repositorios.Context;
using System.Collections.Generic;




public class RepositorioUsuarioGenerico : IRepositorioGenerico
{
    readonly Alquileres_ExpressContext _context;


    public List<Usuario> Listar()
    {
        return [.. _context.Set<Usuario>()];
    }


    public void Registrar<T>(T u) where T : Usuario
    {
        ValidadorUsuario validador = new ();
        validador.Ejecutar(u);
        //validar mail
        if (!_context.Set<Usuario>().Any(user => user.Correo.Equals(u.Correo)))
        {
            u.Contraseña = BCrypt.Net.BCrypt.HashPassword(u.Contraseña.Trim());//.trim() elimina espacios en blanco
            _context.Set<T>().Add(u);
            _context.SaveChanges();
        }
        else
        {
            throw new InvalidOperationException("El correo ya está registrado por otro usuario.");
        }
    }

}