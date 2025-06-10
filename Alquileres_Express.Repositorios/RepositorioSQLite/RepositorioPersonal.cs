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
        return _context.Personal.Find(id) ?? throw new KeyNotFoundException($"No existe el personal con ID {id}. Por favor, intente de nuevo o pruebe otro personal.");
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

     public bool ModificarPersonal(Personal personal)
    {

        var personalExistente = ObtenerPersonalPorId(personal.Id);
        bool ok = true;
        if (personalExistente == null)
        {
            ok = false;
            throw new KeyNotFoundException($"No se encontró un personal con el correo {personal.Correo}");
        }

        bool existe = _context.Clientes.Any(x => x.Correo.ToLower() == personal.Correo.ToLower()) || _context.Personal.Any(x => x.Correo.ToLower() == personal.Correo.ToLower()) && personalExistente.Correo.ToLower() != personal.Correo.ToLower();
        if (existe)
            throw new InvalidOperationException("El correo ya está registrado por otro usuario.");
        personalExistente.Nombre = personal.Nombre;
        personalExistente.Apellido = personal.Apellido;
        
        personalExistente.Correo = personal.Correo;
        personalExistente.Direccion = personal.Direccion;
        personalExistente.Dni = personal.Dni;
        personalExistente.FechaNacimiento = personal.FechaNacimiento;

        _context.SaveChanges();
        return ok;
    }
}