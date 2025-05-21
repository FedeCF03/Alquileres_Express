using System;

using Alquileres_Express.Aplicacion.Interfaces;
namespace Alquileres_Express.Aplicacion.UseCases;

public abstract class UsuarioUseCase(IRepositorioUsuario repositorio)
{
    protected IRepositorioUsuario Repositorio { get; } = repositorio;
}

