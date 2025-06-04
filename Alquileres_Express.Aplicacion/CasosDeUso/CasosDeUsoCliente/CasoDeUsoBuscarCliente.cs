using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;

namespace Alquileres_Express.Aplicacion.CasosDeUso;

public class CasoDeUsoBuscarCliente(IRepositorioCliente repositorio)
{


    public Cliente? Ejecutar(string correo, string contraseña)
    {
        if (string.IsNullOrWhiteSpace(correo) || string.IsNullOrWhiteSpace(contraseña))
        {
            return null;
        }

        return repositorio.ObtenerClientePorMailYContraseña(correo, contraseña);
    }
}