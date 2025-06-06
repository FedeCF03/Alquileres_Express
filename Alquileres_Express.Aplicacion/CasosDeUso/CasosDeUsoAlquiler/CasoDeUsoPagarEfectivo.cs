using Alquileres_Express.Aplicacion.CasosDeUso.CasosDeUsoAlquiler;
using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;

namespace Alquileres_Express.Aplicacion.CasosDeUso.CasosDeUsoPagarEfectivo;


public class CasoDeUsoPagarEfectivo(IRepositorioAlquiler repositorio) : CasoDeUsoAlquiler(repositorio)
{
    public void PagarEfectivo(Alquiler alquiler)
    {
        Repositorio.RegistrarPagoEnEfectivo(alquiler);
    }
}