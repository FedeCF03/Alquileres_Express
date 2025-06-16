using System;
using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;

namespace Alquileres_Express.Aplicacion.CasosDeUso;

public class CasoDeUsoAñadirLlave(IRepositorioLlave repositorio) : CasoDeUsoLLave(repositorio)
{
    public void Ejecutar( RegistroDeLlave registro)
    {
         Repositorio.AñadirRegistroDeLlave(registro);
    }
}
