using System;
using Alquileres_Express.Aplicacion.CasosDeUso.CasosDeUsoAlquiler;
using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;

namespace Alquileres_Express.Aplicacion.CasosDeUso;

public class CasoDeUsoCalificarInmueble(IRepositorioAlquiler repositorio) : CasoDeUsoAlquiler(repositorio)
{
    public bool Ejecutar(int idInmueble, int idCliente, Valoracion valoracion)
    {
        try
        {
            return Repositorio.CalificarAlquiler(idInmueble, idCliente, valoracion);
        }
        catch
        {
            return false;
        }
    }
}
