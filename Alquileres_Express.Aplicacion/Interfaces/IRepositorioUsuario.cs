using System;

using Alquileres_Express.Aplicacion.Entidades;
namespace Alquileres_Express.Aplicacion.Interfaces;

public interface IRepositorioUsuario
{
    List<Usuario> GetUsuarios();
    //void RegistrarUsuario(Usuario u);

    //public Usuario Verificar(String email, String password);
}