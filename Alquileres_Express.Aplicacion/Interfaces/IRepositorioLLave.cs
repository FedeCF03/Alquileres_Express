using System;
using Alquileres_Express.Aplicacion.Entidades;

namespace Alquileres_Express.Aplicacion.Interfaces;

public interface IRepositorioLlave
{
    public RegistroDeLlave RegistrarEntregaLLavePresencial(int idAlquiler, int idPersonal, int idCliente);
}
