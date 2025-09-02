namespace Alquileres_Express.Aplicacion.CasosDeUso;

using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Aplicacion.Enumerativo;
public abstract class CasoDeUsoComentario (IRepositorioComentario repositorioComentario)
{
    protected readonly IRepositorioComentario _repositorioComentario = repositorioComentario;

}