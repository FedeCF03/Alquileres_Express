namespace Alquileres_Express.Aplicacion.CasosDeUso;

using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Aplicacion.Entidades;


public class CasoDeUsoRegistrarUsuario(IRepositorioUsuario repositorio) : CasoDeUsoUsuario(repositorio)
{
    public void Ejecutar(Usuario usuario)
    {
        Repositorio.RegistrarUsuario(usuario);
    }
}