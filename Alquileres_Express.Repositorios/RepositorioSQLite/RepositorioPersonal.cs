using Alquileres_Express.Aplicacion;
using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Enumerativo;
using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Repositorios.Context;

namespace Alquileres_Express.Repositorios.RepositoriosSQLite;

public class RepositorioPersonal : IRepositorioPersonal
{
    readonly Alquileres_ExpressContext _context = new();
    public void AgregarPersonal(Personal c)
    {

    }

    public void ModificarPersonal(Personal c)
    {

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
        throw new NotImplementedException();
    }

    public Personal? ObtenerPersonalPorMailYContraseña(string mail, string contraseña)
    {

        contraseña = BCrypt.Net.BCrypt.HashPassword(contraseña);

        var per = _context.Personal.FirstOrDefault(p => p.Correo == mail && p.Contraseña == contraseña);
        if (per == null)
        {
            return null;
        }
        return per;

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

    public bool ValidarCodigoDeSeguridad(String correo, String codigoDeSeguridad, out RolUsuario rol)
    {
        var personal = _context.Personal.FirstOrDefault(p => p.Correo == correo && p.CodigoDeSeguridad == int.Parse(codigoDeSeguridad));
        if (personal != null)
        {
            personal.CodigoDeSeguridad = 0;
            _context.SaveChanges();
            // Resetear el código de seguridad después de la validación
            rol = personal.Rol;
            return true;
        }
        rol = personal.Rol;
        return false;

    }

   
}