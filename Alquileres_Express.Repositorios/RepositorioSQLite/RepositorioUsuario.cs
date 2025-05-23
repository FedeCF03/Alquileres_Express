namespace Alquileres_Express.Repositorios;

using Microsoft.EntityFrameworkCore;
using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;
public class RepositorioUsuario : IRepositorioUsuario
{
    private readonly List<Usuario> _listaUsuarios = new List<Usuario>()
    /*{
        new Usuario(){ID = 1,
            correo = "maria@gmail.com",
            contraseña = "123456",
            nombre = "Maria",
            apellido = "Torres",
            direccion = "La plata",
            fechaNacimiento = new DateTime(2025, 5, 20)}
    }*/;
    static int _proximoId = 2;
    // public void RegistrarUsuario(Usuario u)
    // {

    // }

    public List<Usuario> GetUsuarios()//Devuelve una copia de la lista de usuarios
    {
        return null;
        //return _listaUsuarios.Select(u => Clonar(u)).ToList();
    }
    public Cliente getUsuario(String email, String password)
    {
        return null;
    }

    public Usuario Verificar(String email, String password)
    {
        return null;
    }
}