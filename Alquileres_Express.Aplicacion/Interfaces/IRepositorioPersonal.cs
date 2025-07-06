using Alquileres_Express.Aplicacion.Entidades;
namespace Alquileres_Express.Aplicacion.Interfaces;

public interface IRepositorioPersonal
{
    public void AgregarPersonal(Personal c);

    public bool ModificarPersonal(Personal c);

    public void EliminarPersonal(int id);
    public Personal ObtenerPersonalPorId(int id);
    public Personal ObtenerPersonalPorDNI(string dni);
    public Personal? ObtenerPersonalPorMail(string mail);
    public List<Personal> ObtenerTodosElPersonal();

    public Personal? ObtenerPersonalPorMailYContraseña(string mail, string contraseña);

    public void ActualizarEstadoDobleAutenticacion(int id, string codigoDeSeguridad);

    public Personal? ValidarCodigoDeSeguridad(String correo, String codigoDeSeguridad);
    public bool SeRepiteDNI(Personal p);
    public bool SeRepiteCorreo(Personal p);
    public void AscenderAGerente(int id);
    public void DescenderGerente(int id);

}