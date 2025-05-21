using System;
using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;

namespace Alquileres_Express.Aplicacion.CasosDeUso;

public class CasoDeUsoListarUsuario(IRepositorioUsuario repositorio) : CasoDeUsoUsuario(repositorio)
{
    public List<Usuario> Ejecutar()
    {
        return Repositorio.GetUsuarios();
    }
}