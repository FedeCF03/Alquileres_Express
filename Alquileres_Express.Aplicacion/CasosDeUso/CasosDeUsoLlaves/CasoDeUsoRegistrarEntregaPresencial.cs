using System;
using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;

namespace Alquileres_Express.Aplicacion.CasosDeUso;

public class CasoDeUsoRegistrarEntregaPresencial(IRepositorioLlave repositorio) : CasoDeUsoLLave(repositorio)
{
    public RegistroDeLlave Ejecutar(int idAlquiler, int idPersonal, int idCliente)
    {
        return Repositorio.RegistrarEntregaLLavePresencial(idAlquiler, idPersonal, idCliente);
    }
}
