using System;
using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Aplicacion.Validadores;

namespace Alquileres_Express.Aplicacion.CasosDeUso.CasosDeUsoAlquiler;

public class CasoDeUsoRegistrarAlquilerPresencial(IRepositorioAlquiler repositorio, ValidadorAlquiler validador) : CasoDeUsoAlquiler(repositorio)
{
    public void Ejecutar(String correo, Inmueble inmueble, DateTime fechaInicio, DateTime fechaFin, int numeroPersonal)
    {
        validador.EstaDisponible(inmueble, fechaInicio, fechaFin);
        Repositorio.RegistrarAlquilerPresencial(correo, inmueble, fechaInicio, fechaFin, numeroPersonal);
    }
}
