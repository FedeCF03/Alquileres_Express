using System;
using Alquileres_Express.Aplicacion.Interfaces;

namespace Alquileres_Express.Aplicacion.CasosDeUso;

public abstract class CasoDeUsoLLave(IRepositorioLlave repositorio)
{
    protected IRepositorioLlave Repositorio { get; } = repositorio; 
}
