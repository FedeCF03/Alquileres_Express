using System;

using Alquileres_Express.Aplicacion.Interfaces;
namespace Alquileres_Express.Aplicacion.CasosDeUso;

public abstract class RepositorioUsuarioUseCase(IRepositorioUsuario repositorio)
{
    protected IRepositorioUsuario Repositorio { get; } = repositorio;
}