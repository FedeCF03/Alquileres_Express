namespace Alquileres_Express.Repositorios.RepositoriosSQLite;

using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;
using System.Collections.Generic;
using Alquileres_Express.Repositorios.Context;
using BCrypt;

public class RepositorioCliente : IRepositorioCliente
{
    readonly Alquileres_ExpressContext _context = new Alquileres_ExpressContext();
    public void AgregarCliente(Cliente c)
    {
        c.Rol = Aplicacion.Enumerativo.RolUsuario.Cliente;
        bool existe = _context.Clientes.Any(x => x.Correo.ToLower() == c.Correo.ToLower()) || _context.Personal.Any(x => x.Correo.ToLower() == c.Correo.ToLower());
        if (existe)
            throw new InvalidOperationException("El correo ya está registrado por otro usuario.");
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
        var cliente = _context.Clientes.FirstOrDefault(x => x.Id == id);

        if (cliente == null)
            throw new InvalidOperationException("No se encontró un cliente con ese ID.");
        return cliente;
    }

    public List<Cliente> ObtenerClientes()
    {
        return _context.Clientes.ToList();
    }

    public void RegistrarCliente(Cliente c)
    {
        throw new NotImplementedException();
    }

    public Cliente ObtenerClientePorDNI(string dni)
    {
        throw new NotImplementedException();
    }

    public Cliente? ObtenerClientePorMail(string mail)
    {
        var cli = _context.Clientes.FirstOrDefault(p => p.Correo == mail);
        if (cli != null)
        {
            return cli;
        }
        return null;
    }

    public Cliente? ObtenerClientePorMailYContraseña(string mail, string contraseña)
    {
        //bool esValida = BCrypt.Net.BCrypt.Verify(contraseñaIngresada, usuario.Contraseña);

        var cli = _context.Clientes.FirstOrDefault(p => p.Correo == mail);
        if (cli != null && BCrypt.Net.BCrypt.Verify(contraseña, cli.Contraseña))
        {
            return cli;
        }
        return null;

    }

    public void ModificarCliente(Cliente cliente)
    {
        var clienteExistente = ObtenerClientePorMail(cliente.Correo);
        if (clienteExistente == null)
        {
            throw new KeyNotFoundException($"No se encontró un cliente con el correo {cliente.Correo}");
        }

        clienteExistente.Nombre = cliente.Nombre;
        clienteExistente.Apellido = cliente.Apellido; 
        bool existe = _context.Clientes.Any(x => x.Correo.ToLower() == cliente.Correo.ToLower()) || _context.Personal.Any(x => x.Correo.ToLower() == cliente.Correo.ToLower()) && clienteExistente.Correo.ToLower() != cliente.Correo.ToLower();
        if (existe)
            throw new InvalidOperationException("El correo ya está registrado por otro usuario.");
        clienteExistente.Correo = cliente.Correo; 
        clienteExistente.Direccion = cliente.Direccion;
        clienteExistente.Dni = cliente.Dni;
        clienteExistente.FechaNacimiento = cliente.FechaNacimiento;

        _context.SaveChanges();
    }


}