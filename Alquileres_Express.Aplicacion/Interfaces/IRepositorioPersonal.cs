using Alquileres_Express.Aplicacion.Entidades;
namespace Alquileres_Express.Aplicacion.Interfaces;

public interface IRepositorioPersonal
{
    public void AgregarPersonal(Personal c);

    public Boolean ModificarPersonal(Personal c);

    public void EliminarPersonal(int id);
    public Personal ObtenerPersonalPorId(int id);
    public Personal ObtenerPersonalPorDNI(string dni);
    public Personal ObtenerPersonalPorMail(string mail);
    public List<Personal> ObtenerTodosElPersonal();
    public List<Personal> ObtenerPersonalPorNombre(string nombre);

    public Personal ObtenerPersonalPorMailYContraseña(string mail, string contraseña);

    public void ActualizarEstadoDobleAutenticacion(int id, string codigoDeSeguridad);

    public Personal ValidarCodigoDeSeguridad(String correo, String codigoDeSeguridad);
    public bool SeRepiteDNI(Personal p);
    public void DescenderGerente(int id);
    public bool SeRepiteCorreo(Personal p);

    public void AscenderAGerente(int id);
}