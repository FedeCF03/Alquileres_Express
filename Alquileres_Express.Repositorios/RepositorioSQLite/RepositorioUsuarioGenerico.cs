namespace Alquileres_Express.Repositorios.RepositoriosSQLite;

using Microsoft.EntityFrameworkCore;
using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Repositorios.Context;
using System.Collections.Generic;

public class RepositorioUsuarioGenerico : IRepositorioGenerico
{
    readonly Alquileres_ExpressContext _context;

    public List<Usuario> Listar()
    {
        return _context.Set<Usuario>().ToList();
    }


    public void Registrar<T>(T u) where T : Usuario
    {
        //validar mail
        //validar contraseña
        //hashear contraseña
        //validar campos
        //validar que sea mayor de edad
        _context.Set<T>().Add(u);
        _context.SaveChanges();
    }




}