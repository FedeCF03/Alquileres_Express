using System;
using Alquileres_Express.Aplicacion.Entidades;

namespace Alquileres_Express.Aplicacion.Interfaces;

public interface IRepositorioAlquiler
{
    public void RegistrarAlquilerPresencial(String correo, int idInmueble, DateTime fechaInicio, DateTime fechaFin, int numeroPersonal);
    public void RegistrarAlquilerVirtual(Alquiler alquiler);
}
