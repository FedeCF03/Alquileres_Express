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
        bool existe = (_context.Clientes.Any(x => x.Correo.ToLower() == c.Correo.ToLower())) || (_context.Personal.Any(x => x.Correo.ToLower() == c.Correo.ToLower()));
        if (existe)
            throw new InvalidOperationException("El correo ya está registrado por otro cliente.");
        c.Contraseña = BCrypt.Net.BCrypt.HashPassword(c.Contraseña.Trim());//.trim() elimina espacios en blanco
        _context.Clientes.Add(c);
        _context.SaveChanges();
    }
    public void EliminarCliente(Cliente c)
    {
        throw new NotImplementedException();

    }

    public void ModificarCliente(Cliente c)
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

    public Cliente ObtenerClientePorMail(string mail)
    {
        throw new NotImplementedException();
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

}