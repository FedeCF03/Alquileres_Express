using System;
using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;

namespace Alquileres_Express.Aplicacion.CasosDeUso;

public class CasoDeUsoEditarValoracion (IRepositorioInmueble repositorio) : CasoDeUsoInmueble(repositorio)
{
    public void Ejecutar(Valoracion valoracion)
    {
        repositorio.EditarValoracion(valoracion);
    }
}
