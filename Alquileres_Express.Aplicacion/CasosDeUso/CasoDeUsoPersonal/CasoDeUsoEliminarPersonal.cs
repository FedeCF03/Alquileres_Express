namespace Alquileres_Express.Aplicacion.CasosDeUso;

using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;

public class CasoDeUsoEliminarPersonal(IRepositorioPersonal _repositorioPersonal)
{
    public void Ejecutar(int id)
    {

        _repositorioPersonal.EliminarPersonal(id);
    }
}