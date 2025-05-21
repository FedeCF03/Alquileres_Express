using System;
using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;

namespace Alquileres_Express.Aplicacion.UseCases;

public class ListarUsuarioUseCase(IRepositorioUsuario repositorio) : UsuarioUseCase(repositorio)
{
    public List<Usuario> Ejecutar()
    {
        return Repositorio.GetUsuarios();
    }
}
