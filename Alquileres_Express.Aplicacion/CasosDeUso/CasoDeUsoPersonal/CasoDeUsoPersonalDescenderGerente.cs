namespace Alquileres_Express.Aplicacion.CasosDeUso;

using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;

public class CasoDeUsoPersonalDescenderGerente(IRepositorioPersonal repositorio) : CasoDeUsoPersonal(repositorio)
{
    public void Ejecutar(int id)
    {
        try
        {
            Repositorio.DescenderGerente(id);

        }
        catch (Exception ex)
        {

            throw new InvalidOperationException($"Error al descender al gerente con ID {id}: {ex.Message}");
        }
    }
}