using Alquileres_Express.Aplicacion;
using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Repositorios.Context;
using Microsoft.EntityFrameworkCore;

namespace Alquileres_Express.Repositorios.RepositorioSQLite;

public class RepositorioPersonal : IRepositorioPersonal
{
        private readonly Alquileres_ExpressContext _context;
        public void AgregarPersonal(Personal p)
        {
            using Alquileres_ExpressContext _context = new();
            bool existe = (_context.Clientes.Any(x => x.Correo.ToLower() == p.Correo.ToLower())) || (_context.Personal.Any(x => x.Correo.ToLower() == p.Correo.ToLower()));
            if (existe)
                throw new InvalidOperationException("El correo ya está registrado por otro usuario.");
            bool dniExiste = _context.Clientes.Any(x => x.Dni == p.Dni) || _context.Personal.Any(x => x.Dni == p.Dni);
            if (dniExiste)
                throw new InvalidOperationException("El DNI ya está registrado por otro usuario.");
            p.Contraseña = BCrypt.Net.BCrypt.HashPassword(p.Contraseña.Trim());
            p.Rol = Aplicacion.Enumerativo.RolUsuario.Empleado;
            _context.Personal.Add(p);
            _context.SaveChanges();
        }

    public void EliminarPersonal(Personal c)
    {

    }
    public Personal ObtenerPersonalPorId(int id)
    {
        using Alquileres_ExpressContext _context = new();
        return _context.Personal.Include(c => c.RegistrosDeLlave).FirstOrDefault(p => p.Id == id) ?? throw new KeyNotFoundException($"No existe el personal con ID {id}. Por favor, intente de nuevo o pruebe otro personal.");
    }
    public List<Personal> ObtenerTodosElPersonal()
    {
        using Alquileres_ExpressContext _context = new();
        return _context.Personal.Include(c => c.RegistrosDeLlave).ToList();
    }
    public List<Personal> ObtenerPersonalPorNombre(string nombre)
    {
        using Alquileres_ExpressContext _context = new();
        throw new NotImplementedException();
    }

    public Personal ObtenerPersonalPorDNI(string dni)
    {
        using Alquileres_ExpressContext _context = new();
        var per = _context.Personal.Include(p => p.RegistrosDeLlave).FirstOrDefault(p => p.Dni == dni);
        if (per != null)
        {
            return per;
        }
        throw new KeyNotFoundException($"No existe el personal con DNI {dni}. Por favor, intente de nuevo o pruebe otro personal.");
    }

    public Personal ObtenerPersonalPorMail(string mail)
    {
        using Alquileres_ExpressContext _context = new();
        var per = _context.Personal.Include(c => c.RegistrosDeLlave).FirstOrDefault(p => p.Correo == mail);
        if (per != null)
        {
            return per;
        }
        return null;

    }

    public Personal? ObtenerPersonalPorMailYContraseña(string mail, string contraseña)
    {
        using Alquileres_ExpressContext _context = new();
        var per = _context.Personal.Include(c => c.RegistrosDeLlave).FirstOrDefault(p => p.Correo == mail);
        if (per != null && BCrypt.Net.BCrypt.Verify(contraseña, per.Contraseña))
        {
            return per;
        }
        return null;
    }


    public void ActualizarEstadoDobleAutenticacion(int id, string codigoDeSeguridad)
    {
        using Alquileres_ExpressContext _context = new();
        var personal = _context.Personal.FirstOrDefault(p => p.Id == id);
        if (personal != null)
        {
            personal.CodigoDeSeguridad = int.Parse(codigoDeSeguridad);
            _context.SaveChanges();
        }

    }

    public Personal ValidarCodigoDeSeguridad(string correo, string codigoDeSeguridad)
    {
        using Alquileres_ExpressContext _context = new();
        var personal = _context.Personal.FirstOrDefault(p => p.Correo == correo && p.CodigoDeSeguridad == int.Parse(codigoDeSeguridad));
        if (personal != null)
        {
            personal.CodigoDeSeguridad = 0;
            _context.SaveChanges();
            // Resetear el código de seguridad después de la validación
        }
        return personal;

    }

    //  public bool ModificarPersonal(Personal personal)
    // {
    //     var clienteExistente = ObtenerPersonalPorId(personal.Id);
    //     bool ok = true;
    //     if (clienteExistente == null)
    //     {
    //         ok = false;
    //         throw new KeyNotFoundException($"No se encontró un personal con el correo {personal.Correo}");
    //     }

    //     clienteExistente.Nombre = personal.Nombre;
    //     clienteExistente.Apellido = personal.Apellido;

    //     clienteExistente.Correo = personal.Correo;
    //     clienteExistente.Direccion = personal.Direccion;
    //     clienteExistente.Dni = personal.Dni;
    //     clienteExistente.FechaNacimiento = personal.FechaNacimiento;
    //     _context.SaveChanges();
    //     return ok;
    // }


    public bool ModificarPersonal(Personal personal)
{
    using Alquileres_ExpressContext _context = new();
    var personalExistente = _context.Personal.FirstOrDefault(p => p.Id == personal.Id);
    if (personalExistente == null)
        return false; // O lanzar una excepción, según el caso
    
    personalExistente.Nombre = personal.Nombre;
    personalExistente.Apellido = personal.Apellido;
    personalExistente.Correo = personal.Correo;
    personalExistente.Direccion = personal.Direccion;
    personalExistente.Dni = personal.Dni;
    personalExistente.FechaNacimiento = personal.FechaNacimiento;

    _context.SaveChanges();
    return true;
}
    public bool SeRepiteDNI(Personal cliente)
    {
        using Alquileres_ExpressContext _context = new();
        Usuario? u = _context.Clientes.FirstOrDefault(c => c.Dni.Equals(cliente.Dni));

        Usuario? u2 = _context.Personal.FirstOrDefault(p => p.Dni.Equals(cliente.Dni) && p.Id != cliente.Id);
        return u != null || u2 != null;

    }
    public bool SeRepiteCorreo(Personal cliente)
    {
        using Alquileres_ExpressContext _context = new();
        return _context.Clientes.FirstOrDefault(c => c.Correo.ToLower().Equals(cliente.Correo.ToLower())) != null ||
        _context.Personal.FirstOrDefault(p => p.Correo.ToLower().Equals(cliente.Correo.ToLower()) && p.Id != cliente.Id) != null;
    }
}