using Alquileres_Express.Aplicacion.Entidades;
namespace Alquileres_Express.Aplicacion.Interfaces;

public interface IRepositorioPersonal
{
    public void AgregarPersonal(Personal c);

    public void ModificarPersonal(Personal c);

    public void EliminarPersonal(Personal c);
    public Personal ObtenerPersonalPorId(int id);
    public Personal ObtenerPersonalPorDNI(string dni);
    public Personal ObtenerPersonalPorMail(string mail);
    public List<Personal> ObtenerTodosElPersonal();
    public List<Personal> ObtenerPersonalPorNombre(string nombre);

    public Personal ObtenerPersonalPorMailYContraseña(string mail, string contraseña);

    public void ActualizarEstadoDobleAutenticacion(int id, string codigoDeSeguridad);

    public Personal ValidarCodigoDeSeguridad(String correo, String codigoDeSeguridad);

}