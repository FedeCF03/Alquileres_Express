using System;
using Alquileres_Express.Aplicacion.Interfaces;

namespace Alquileres_Express.Aplicacion.CasosDeUso.CasosDeUsoLlaves;

public abstract class CasoDeUsoLLave(IRepositorioLLave repositorio)
{
    protected IRepositorioLLave Repositorio { get; } = repositorio; 
}
