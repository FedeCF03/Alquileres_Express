using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;

namespace Alquileres_Express.Aplicacion.CasosDeUso;

public class CasoDeUsoListarCLiente(IRepositorioPersonal repositorio)// : CasoDeUsoCLiente(repositorio)
{
    public List<Usuario> Ejecutar()
    {
        //return repositorio.GetUsuarios();
        return null;
    }
}