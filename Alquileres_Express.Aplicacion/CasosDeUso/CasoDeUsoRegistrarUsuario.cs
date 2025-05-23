namespace Alquileres_Express.Aplicacion.CasosDeUso;

using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Aplicacion.Entidades;


public class CasoDeUsoRegistrarUsuario(IRepositorioCliente repositorio) : CasoDeUsoCliente(repositorio)
{
    public void Ejecutar(Cliente cli)
    {
        Repositorio.RegistrarCliente(cli);
    }
}