using System;
using Alquileres_Express.Aplicacion.Entidades;

namespace Alquileres_Express.Aplicacion.Validadores;

public class ValidadorAlquiler
{
    public void EstaDisponible(Inmueble inmueble, DateTime fechaInicio, DateTime fechaFin)
    {
        ValidarFechas(fechaInicio, fechaFin);
        ValidarDisponibilidad(inmueble, fechaInicio, fechaFin);
    }

    private void ValidarFechas(DateTime fechaInicio, DateTime fechaFin)
    {
        if (fechaInicio >= fechaFin)
            throw new InvalidOperationException("La fecha de inicio debe ser anterior a la fecha de fin.");
    }

    private void ValidarDisponibilidad(Inmueble inmueble, DateTime fechaInicio, DateTime fechaFin)
    {
        if (inmueble.Alquileres == null || inmueble.Alquileres.Count == 0)
            return; // No hay alquileres registrados, por lo que el inmueble está disponible

        bool estaOcupado = inmueble.Alquileres.Any(a => fechaInicio < a.FechaDeFin && fechaFin > a.FechaDeInicio);

        if (estaOcupado)
            throw new InvalidOperationException("El inmueble ya está alquilado en las fechas seleccionadas.");
    }


}
