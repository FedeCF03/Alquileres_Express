using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;

namespace Alquileres_Express.Aplicacion.CasosDeUso;

public class CasoDeUsoBuscarClientePorCorreo(IRepositorioCliente repositorio)
{


    public Cliente? Ejecutar(string correo)
    {
        if (string.IsNullOrWhiteSpace(correo))
        {
            return null;
        }

        return repositorio.ObtenerClientePorMail(correo);
    }
}