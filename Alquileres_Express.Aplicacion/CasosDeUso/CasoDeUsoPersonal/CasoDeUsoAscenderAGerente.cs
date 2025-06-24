using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;
namespace Alquileres_Express.Aplicacion.CasosDeUso;

public class CasoDeUsoAscenderAGerente(IRepositorioPersonal _repositorioPersonal)
{
    public void Ejecutar(int id)
    {

        _repositorioPersonal.AscenderAGerente(id);
    }
}