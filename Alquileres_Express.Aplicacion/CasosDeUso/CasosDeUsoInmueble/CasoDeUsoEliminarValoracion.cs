using System;
using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;

namespace Alquileres_Express.Aplicacion.CasosDeUso;

public class CasoDeUsoEliminarValoracion(IRepositorioInmueble repositorio) : CasoDeUsoInmueble(repositorio)
{
    public async Task<bool> Ejecutar(Valoracion valoracion)
    {
        return await repositorio.EliminarValoracion(valoracion);
    }
}
