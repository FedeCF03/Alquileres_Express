using Alquileres_Express.Aplicacion;
using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Repositorios.Context;

namespace Alquileres_Express.Repositorios.RepositorioSQLite;

public class RepositorioPersonal : IRepositorioPersonal
{
    readonly Alquileres_ExpressContext _context = new Alquileres_ExpressContext();
    public void AgregarPersonal(Personal p)
    {
        bool existe = (_context.Clientes.Any(x => x.Correo.ToLower() == p.Correo.ToLower())) || (_context.Personal.Any(x => x.Correo.ToLower() == p.Correo.ToLower()));
        if (existe)
            throw new InvalidOperationException("El correo ya está registrado por otro usuario.");
        p.Contraseña = BCrypt.Net.BCrypt.HashPassword(p.Contraseña.Trim());
        _context.Personal.Add(p);
        _context.SaveChanges();
    }

    public void EliminarPersonal(Personal c)
    {

    }
    public Personal ObtenerPersonalPorId(int id)
    {
        return null;
    }
    public List<Personal> ObtenerTodosElPersonal()
    {
        return null;
    }
    public List<Personal> ObtenerPersonalPorNombre(string nombre)
    {
        return null;
    }

    public Personal ObtenerPersonalPorDNI(string dni)
    {
        throw new NotImplementedException();
    }

    public Personal ObtenerPersonalPorMail(string mail)
    {
        var per = _context.Personal.FirstOrDefault(p => p.Correo == mail);
        if (per != null)
        {
            return per;
        }
        return null;
    
    }

    public Personal? ObtenerPersonalPorMailYContraseña(string mail, string contraseña)
    {

        var per = _context.Personal.FirstOrDefault(p => p.Correo == mail);
        if (per != null && BCrypt.Net.BCrypt.Verify(contraseña, per.Contraseña))
        {
            return per;
        }
        return null;
    }
    

    public void ActualizarEstadoDobleAutenticacion(int id, string codigoDeSeguridad)
    {
        var personal = _context.Personal.FirstOrDefault(p => p.Id == id);
        if (personal != null)
        {
            personal.CodigoDeSeguridad = int.Parse(codigoDeSeguridad);
            _context.SaveChanges();
        }

    }

    public Personal ValidarCodigoDeSeguridad(String correo, String codigoDeSeguridad)
    {
        var personal = _context.Personal.FirstOrDefault(p => p.Correo == correo && p.CodigoDeSeguridad == int.Parse(codigoDeSeguridad));
        if (personal != null)
        {
            personal.CodigoDeSeguridad = 0;
            _context.SaveChanges();
            // Resetear el código de seguridad después de la validación
        }
        return personal;

    }

     public void ModificarPersonal(Personal personal)
    {

        //lo del nombre se checke en el caso de uso, no es necesario hacerlo aquí
        using var _context = new Alquileres_ExpressContext();
        Personal personalExistente = _context.Personal.Find(personal.Id)
        ?? throw new KeyNotFoundException($"No se encontró un personal con el ID {personal.Id}");

        personalExistente.Nombre = personal.Nombre;
        personalExistente.Direccion = personal.Direccion;
        personalExistente.FechaNacimiento = personal.FechaNacimiento;
        personalExistente.Apellido = personal.Apellido;
        personalExistente.Correo = personal.Correo;
        personalExistente.Dni = personal.Dni;
        _context.SaveChanges();
    }
}