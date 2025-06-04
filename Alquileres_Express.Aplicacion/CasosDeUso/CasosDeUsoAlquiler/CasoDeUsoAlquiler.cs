using System;
using Alquileres_Express.Aplicacion.Interfaces;

namespace Alquileres_Express.Aplicacion.CasosDeUso.CasosDeUsoAlquiler;

public abstract class CasoDeUsoAlquiler(IRepositorioAlquiler repositorio)
{
    protected IRepositorioAlquiler Repositorio { get; } = repositorio;
}
