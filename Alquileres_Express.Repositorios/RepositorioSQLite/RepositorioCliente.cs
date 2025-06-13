namespace Alquileres_Express.Repositorios.RepositoriosSQLite;

using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;
using System.Collections.Generic;
using Alquileres_Express.Repositorios.Context;
using BCrypt;
using Microsoft.EntityFrameworkCore;

public class RepositorioCliente : IRepositorioCliente
{
    readonly Alquileres_ExpressContext _context = new Alquileres_ExpressContext();
    public void AgregarCliente(Cliente c)
    {
        c.Rol = Aplicacion.Enumerativo.RolUsuario.Cliente;
        bool existe = _context.Clientes.Any(x => x.Correo.ToLower() == c.Correo.ToLower()) || _context.Personal.Any(x => x.Correo.ToLower() == c.Correo.ToLower());
        if (existe)
            throw new InvalidOperationException("El correo ya está registrado por otro usuario.");
        bool dniExiste = _context.Clientes.Any(x => x.Dni == c.Dni) || _context.Personal.Any(x => x.Dni == c.Dni);
        if (dniExiste)
            throw new InvalidOperationException("El DNI ya está registrado por otro usuario.");
        c.Contraseña = BCrypt.Net.BCrypt.HashPassword(c.Contraseña.Trim());//.trim() elimina espacios en blanco
        _context.Clientes.Add(c);
        _context.SaveChanges();
    }
    public void EliminarCliente(Cliente c)
    {
        throw new NotImplementedException();

    }

    public Cliente ObtenerClientePorId(int id)
    {
        return _context.Clientes.Include(c => c.Alquileres).Include(c => c.RegistrosDeLlave).FirstOrDefault(c => c.Id == id) ?? throw new KeyNotFoundException($"No existe el personal con ID {id}. Por favor, intente de nuevo o pruebe otro personal.");
    }

    public List<Cliente> ObtenerClientes()
    {
        return _context.Clientes.Include(c => c.Alquileres).Include(c => c.RegistrosDeLlave).ToList();
    }

    public Cliente ObtenerClientePorDNI(string dni)
    {
        return _context.Clientes.Include(c => c.Alquileres).Include(c => c.RegistrosDeLlave).FirstOrDefault(p => p.Dni == dni) ?? throw new KeyNotFoundException($"No existe el cliente con DNI {dni}. Por favor, intente de nuevo o pruebe otro cliente.");
    }

    public Cliente? ObtenerClientePorMail(string mail)
    {
        var cli = _context.Clientes.Include(c => c.Alquileres).Include(c => c.RegistrosDeLlave).FirstOrDefault(p => p.Correo == mail);
        if (cli != null)
        {
            return cli;
        }
        return null;
    }

    public Cliente? ObtenerClientePorMailYContraseña(string mail, string contraseña)
    {
        //bool esValida = BCrypt.Net.BCrypt.Verify(contraseñaIngresada, usuario.Contraseña);

        var cli = _context.Clientes.Include(c => c.Alquileres).Include(c => c.RegistrosDeLlave).FirstOrDefault(p => p.Correo == mail);
        if (cli != null && BCrypt.Net.BCrypt.Verify(contraseña, cli.Contraseña))
        {
            return cli;
        }
        return null;

    }

    public bool ModificarCliente(Cliente cliente)
    {

        var clienteExistente = ObtenerClientePorId(cliente.Id);
        bool ok = true;
        if (clienteExistente == null)
        {
            ok = false;
            throw new KeyNotFoundException($"No se encontró un personal con el correo {cliente.Correo}");
        }

        clienteExistente.Nombre = cliente.Nombre;
        clienteExistente.Apellido = cliente.Apellido;

        clienteExistente.Correo = cliente.Correo;
        clienteExistente.Direccion = cliente.Direccion;
        clienteExistente.Dni = cliente.Dni;
        clienteExistente.FechaNacimiento = cliente.FechaNacimiento;
        _context.SaveChanges();
        return ok;

    }


    public bool SeRepiteDNI(Cliente cliente)
    {
        Usuario? u = _context.Clientes.FirstOrDefault(c => c.Dni.Equals(cliente.Dni) && c.Id != cliente.Id);

        Usuario? u2 = _context.Personal.FirstOrDefault(p => p.Dni.Equals(cliente.Dni));
        return u != null || u2 != null;

    }
    public bool SeRepiteCorreo(Cliente cliente)
    {
        return _context.Clientes.FirstOrDefault(c => c.Correo.ToLower().Equals(cliente.Correo.ToLower()) && c.Id != cliente.Id) != null ||
        _context.Personal.FirstOrDefault(p => p.Correo.ToLower().Equals(cliente.Correo.ToLower()) && p.Id != cliente.Id) != null;
    }


}