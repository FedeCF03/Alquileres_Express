using System;

using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Aplicacion.Entidades;
namespace Alquileres_Express.Aplicacion.CasosDeUso;

public class CasoDeUsoRegistrarUsuario(IRepositorioUsuario repositorio) : CasoDeUsoUsuario(repositorio)
{
    public void Ejecutar(Usuario usuario)
    {
        Repositorio.RegistrarUsuario(usuario);
    }
}