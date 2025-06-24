using System;
using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;

namespace Alquileres_Express.Aplicacion.CasosDeUso;

public class CasoDeUsoListarValoraciones (IRepositorioInmueble repositorio): CasoDeUsoInmueble(repositorio)
{
    public List<Valoracion> Ejecutar(int idInmueble)
    {
        return Repositorio.ObtenerValoracionesPorInmueble(idInmueble);
    }
}
