

using System;
using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Enumerativo;
using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Aplicacion.Validadores;

namespace Alquileres_Express.Aplicacion.CasosDeUso.CasosDeUsoAlquiler;

public class CasoDeUsoAlquilerGetEstadoDeAlquiler(IRepositorioAlquiler repositorio) : CasoDeUsoAlquiler(repositorio)
{
    public EstadoDeAlquiler Ejecutar(int id)
    {
        return Repositorio.GetEstadoDeAlquiler(id);
    }
}
