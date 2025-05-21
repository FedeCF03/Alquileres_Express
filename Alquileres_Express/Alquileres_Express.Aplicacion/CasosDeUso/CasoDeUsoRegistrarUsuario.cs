using System;

using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Aplicacion.Entidades;
namespace Alquileres_Express.Aplicacion.UseCases;

public class RegistrarUsuarioUseCase(IRepositorioUsuario repositorio) : UsuarioUseCase(repositorio)
{
    public void Ejecutar(Usuario usuario)
    {
        Repositorio.RegistrarUsuario(usuario);
    }
}