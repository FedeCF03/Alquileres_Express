using System;
using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Aplicacion.Validadores;

namespace Alquileres_Express.Aplicacion.CasosDeUso.CasosDeUsoAlquiler;

public class CasoDeUsoRegistrarAlquilerPresencial(IRepositorioAlquiler repositorio, ValidadorAlquiler validador) : CasoDeUsoAlquiler(repositorio)
{
    public void Ejecutar(string correo, int idInmueble, DateTime fechaInicio, DateTime fechaFin, int numeroPersonal)
    {
        Repositorio.RegistrarAlquilerPresencial(correo, idInmueble, fechaInicio, fechaFin, numeroPersonal);
    }
}
