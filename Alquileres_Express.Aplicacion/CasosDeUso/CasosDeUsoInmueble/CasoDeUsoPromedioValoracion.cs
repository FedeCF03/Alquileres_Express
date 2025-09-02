using System;
using Alquileres_Express.Aplicacion.Interfaces;

namespace Alquileres_Express.Aplicacion.CasosDeUso;

public class CasoDeUsoPromedioValoracion (IRepositorioInmueble repostorio) : CasoDeUsoInmueble(repostorio)
{
    public void Ejecutar(int idInmueble)
    {
        Repositorio.PromedioValoracion(idInmueble);
    }   
}
