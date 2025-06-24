namespace Alquileres_Express.Repositorios.RepositorioSQLite;
using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Enumerativo;
using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Repositorios.Context;
using Microsoft.EntityFrameworkCore;

public class RepositorioUsuario : IRepositorioUsuario
{

    public List<Usuario> ListarUsuarios()
    {
        using Alquileres_ExpressContext _context = new();
        List<Usuario> users = [];
        List<Cliente> clientes = _context.Clientes.ToList();
        List<Personal> personal = _context.Personal.ToList();
        users.AddRange(clientes);
        users.AddRange(personal);
        return users;
        

        //return clientes.Concat<Personal>(personal).ToList();
    }

    public List<Usuario> ListarRestringido()
    {
        using Alquileres_ExpressContext _context = new();
        List<Usuario> users = new List<Usuario>();
        List<Cliente> clientes = _context.Clientes.Where(p => p.Rol == RolUsuario.Cliente).ToList();
        List<Personal> empleados = _context.Personal.Where(p => p.Rol == RolUsuario.Empleado).ToList();

        users.AddRange(clientes);
        users.AddRange(empleados);

        return users;
    }

}
