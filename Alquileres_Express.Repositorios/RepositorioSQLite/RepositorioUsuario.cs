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

    public bool existeEmail(string email)
    {
        using Alquileres_ExpressContext _context = new();
        return _context.Clientes.Any(c => c.Correo == email) || _context.Personal.Any(p => p.Correo == email);
    }

    public void CambiarContrasena(string correo, string nuevaContrasena)
    {
        using Alquileres_ExpressContext _context = new();
        Usuario usuario = _context.Clientes.FirstOrDefault(c => c.Correo == correo) as Usuario ?? _context.Personal.FirstOrDefault(p => p.Correo == correo);
        if (usuario != null)
        {

            usuario.Contraseña = BCrypt.Net.BCrypt.HashPassword(nuevaContrasena.Trim());
            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
