using System;
using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;

namespace Alquileres_Express.Aplicacion.CasosDeUso;

public class CasoDeUsoListarRestringido (IRepositorioUsuario repositorioUsuario) : CasoDeUsoUsuario (repositorioUsuario)
{
    public List<Usuario> Ejecutar()
    {
        return Repositorio.ListarRestringido();
    }
}
