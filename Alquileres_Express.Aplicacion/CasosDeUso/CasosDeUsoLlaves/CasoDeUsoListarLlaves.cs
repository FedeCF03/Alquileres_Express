using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;

namespace Alquileres_Express.Aplicacion.CasosDeUso;
public class CasoDeUsoListarLlaves(IRepositorioLlave repositorio) : CasoDeUsoLLave(repositorio)
{
    public List<RegistroDeLlave> Ejecutar(int idAlquiler, bool? esEntrega = null)
    {
       return repositorio.ListarRegistroLlaves(idAlquiler, esEntrega);
    }
}
