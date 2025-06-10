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
        c.Rol = Aplicacion.Enumerativo.RolUsuario.Gerente;
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
         return _context.Clientes.Find(id) ?? throw new KeyNotFoundException($"No existe el personal con ID {id}. Por favor, intente de nuevo o pruebe otro personal.");
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

    public Boolean ModificarCliente(Cliente cliente)
    {
       
        var clienteExistente = ObtenerClientePorId(cliente.Id);
        bool ok = true;
        if (clienteExistente == null)
        {
            ok = false;
            throw new KeyNotFoundException($"No se encontró un personal con el correo {cliente.Correo}");
        }

        bool existe = _context.Clientes.Any(x => x.Correo.ToLower() == cliente.Correo.ToLower()) || _context.Personal.Any(x => x.Correo.ToLower() == cliente.Correo.ToLower()) && clienteExistente.Correo.ToLower() != cliente.Correo.ToLower();
        if (existe)
            throw new InvalidOperationException("El correo ya está registrado por otro usuario.");
        clienteExistente.Nombre = cliente.Nombre;
        clienteExistente.Apellido = cliente.Apellido;
        
        clienteExistente.Correo = cliente.Correo;
        clienteExistente.Direccion = cliente.Direccion;
        clienteExistente.Dni = cliente.Dni;
        clienteExistente.FechaNacimiento = cliente.FechaNacimiento;
        _context.SaveChanges();
        return ok;



    }


}