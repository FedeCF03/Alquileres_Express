namespace Alquileres_Express.Aplicacion.CasosDeUso;

using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Aplicacion.Validadores;

public class CasoDeUsoAltaCliente(ValidadorUsuario validador, IRepositorioCliente repo)
{
    public bool Ejecutar(Cliente c, out List<string> errores)
    {
        errores = validador.Ejecutar(c);
        if (c.Dni != null && repo.SeRepiteDNI(c))
        {
            errores.Add("El DNI ya está registrado por otro usuario.");
        }
        if (c.Correo != null && repo.SeRepiteCorreo(c))
        {
            errores.Add("El correo ya está registrado por otro usuario.");
        }
        if (errores.Count > 0)
            return false;
        try
        {
            repo.AgregarCliente(c);
            return true;
        }
        catch (Exception ex)
        {
            errores.Add(ex.Message);
            return false;
        }
    }
}


