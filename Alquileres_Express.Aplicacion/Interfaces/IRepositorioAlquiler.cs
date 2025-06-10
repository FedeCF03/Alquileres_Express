using System;
using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Enumerativo;

namespace Alquileres_Express.Aplicacion.Interfaces;

public interface IRepositorioAlquiler
{
    public void RegistrarAlquilerPresencial(String correo, int idInmueble, DateTime fechaInicio, DateTime fechaFin, int numeroPersonal);
    public void RegistrarAlquilerVirtual(Alquiler alquiler);

    public List<Alquiler> ObtenerAlquileresPorCorreo(string correoCliente);

    public List<Alquiler> ObtenerTodosLosAlquileres();
    public EstadoDeAlquiler GetEstadoDeAlquiler(int idAlquiler);
    public void cancelarAlquiler(int idAlquiler);

    public List<Alquiler> ObtenerAlquilerPorId(int idAlquiler);

}
