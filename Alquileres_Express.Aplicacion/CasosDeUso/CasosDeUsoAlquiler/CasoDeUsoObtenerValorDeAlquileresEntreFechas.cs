using System;
using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Aplicacion.Validadores;

namespace Alquileres_Express.Aplicacion.CasosDeUso.CasosDeUsoAlquiler;

public class CasoDeUsoObtenerValorDeAlquileresEntreFechas(IRepositorioAlquiler repositorio, ValidadorAlquiler validador) : CasoDeUsoAlquiler(repositorio)
{
    public decimal Ejecutar(DateTime fechaInicio, DateTime fechaFin)
    {
        return Repositorio.ObtenerValorDeAlquileresEntreFechas(fechaInicio, fechaFin);
    }
}
