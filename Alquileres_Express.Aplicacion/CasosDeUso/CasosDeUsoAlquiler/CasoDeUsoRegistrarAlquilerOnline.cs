using System;
using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Aplicacion.Validadores;

namespace Alquileres_Express.Aplicacion.CasosDeUso.CasosDeUsoAlquiler;

public class CasoDeUsoRegistrarAlquilerOnline(IRepositorioAlquiler repositorio, ValidadorAlquiler validador) : CasoDeUsoAlquiler(repositorio)
{
    public void Ejecutar(Alquiler alquiler)
    {
        Repositorio.RegistrarAlquilerVirtual(alquiler);
    }
}
