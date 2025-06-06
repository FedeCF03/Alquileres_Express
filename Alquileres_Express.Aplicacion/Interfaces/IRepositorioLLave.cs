using System;
using Alquileres_Express.Aplicacion.Entidades;

namespace Alquileres_Express.Aplicacion.Interfaces;

public interface IRepositorioLLave
{
    public RegistroDeLlave RegistrarEntregaLLavePresencial(int idAlquiler, int idPersonal, int idCliente);
}
