namespace Alquileres_Express.Aplicacion.CasosDeUso;

using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Aplicacion.Validadores;

public class CasoDeUsoAltaCliente(ValidadorUsuario validador, IRepositorioCliente repo)
{
    public ValidadorUsuario Validador { get; set; } = validador;
    private IRepositorioCliente Repo { get; set; } = repo;

    public bool Ejecutar(Cliente c)
    {
        try
        {
            if (!Validador.Ejecutar(c))
            {
                return false; // Si la validación falla, retornamos false
            }
            Repo.AgregarCliente(c);
            return true;

        }
        catch (Exception ex)
        {
            return false;
        }
    }
}


