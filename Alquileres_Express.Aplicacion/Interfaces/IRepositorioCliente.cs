using System;

using Alquileres_Express.Aplicacion.Entidades;
namespace Alquileres_Express.Aplicacion.Interfaces;

public interface IRepositorioCliente
{
    //List<Usuario> GetUsuarios();
    void RegistrarCliente(Cliente c);

}