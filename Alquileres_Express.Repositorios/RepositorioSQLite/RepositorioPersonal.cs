using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;

namespace Alquileres_Express.Repositorios.RepositoriosSQLite;

public class RepositorioPersonal : IRepositorioPersonal
{
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
}