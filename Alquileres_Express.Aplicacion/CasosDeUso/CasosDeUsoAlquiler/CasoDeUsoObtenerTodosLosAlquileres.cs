
using System;
using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Aplicacion.Validadores;

namespace Alquileres_Express.Aplicacion.CasosDeUso.CasosDeUsoAlquiler;

public class CasoDeUsoObtenerTodosLosAlquileres(IRepositorioAlquiler repositorio, ValidadorAlquiler validador) : CasoDeUsoAlquiler(repositorio)
{
    public List<Alquiler> Ejecutar()
    {
        return Repositorio.ObtenerTodosLosAlquileres();
    }
}
