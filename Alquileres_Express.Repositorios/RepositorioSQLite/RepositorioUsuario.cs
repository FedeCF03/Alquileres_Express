namespace Alquileres_Express.Repositorios.RepositorioSQLite;
using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Repositorios.Context;
using Microsoft.EntityFrameworkCore;

public class RepositorioUsuario : IRepositorioUsuario
{
    readonly Alquileres_ExpressContext _context = new Alquileres_ExpressContext();


    public List<Usuario> ListarUsuarios()
    {
        List<Usuario> users = [];
        List<Cliente> clientes = _context.Clientes.ToList();
        List<Personal> personal = _context.Personal.ToList();
        users.AddRange(clientes);
        users.AddRange(personal);
        return users;
        

        //return clientes.Concat<Personal>(personal).ToList();
    }

}
