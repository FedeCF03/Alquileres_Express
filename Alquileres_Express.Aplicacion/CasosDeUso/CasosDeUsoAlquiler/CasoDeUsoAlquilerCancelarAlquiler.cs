

using System;
using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Enumerativo;
using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Aplicacion.Validadores;

namespace Alquileres_Express.Aplicacion.CasosDeUso.CasosDeUsoAlquiler;

public class CasoDeUsoAlquilerCancelarAlquiler(IRepositorioAlquiler repositorio) : CasoDeUsoAlquiler(repositorio)
{
    public void Ejecutar(int id)
    {
        repositorio.cancelarAlquiler(id);
    }
}
