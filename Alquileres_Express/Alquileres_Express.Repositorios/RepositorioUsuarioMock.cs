using System;

using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Aplicacion.Entidades;
namespace Alquileres_Express.Repositorios;

public class RepositorioUsuarioMock : IRepositorioUsuario
{
    private readonly List<Usuario> _listaUsuarios = new List<Usuario>()
    {
        new Usuario(){ID = 1,
            correo = "maria@gmail.com",
            contraseña = "123456",
            nombre = "Maria",
            apellido = "Torres",
            direccion = "La plata",
            fechaNacimiento = new DateTime(2025, 5, 20)}
    };

    static int _proximoId = 2;
    private Usuario Clonar(Usuario u) //Explicar uso del clonar
    {
        return new Usuario()
        {
            ID = u.ID,
            correo = u.correo,
            contraseña = u.contraseña,
            nombre = u.nombre,
            apellido = u.apellido,
            direccion = u.direccion,
            fechaNacimiento = u.fechaNacimiento
        };
    }
    public void RegistrarUsuario(Usuario u)
    {
        u.ID = _proximoId++;
        //cargar los datos del cliente desde blazor
        _listaUsuarios.Add(Clonar(u));//Crea un nuevo usuario y lo agrega a la lista
    }

    public List<Usuario> GetUsuarios()//Devuelve una copia de la lista de usuarios
    {
        return _listaUsuarios.Select(u => Clonar(u)).ToList();
    }
}
