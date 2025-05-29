namespace Alquileres_Express.Aplicacion.CasosDeUso;

using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Aplicacion.Validadores;

public class CasoDeUsoAltaCliente(ValidadorUsuario validador, IRepositorioCliente repo)
{
    public bool Ejecutar(Cliente c)
    {
        // Si algo está mal, lanza una excepción y se puede capturar en la UI
        validador.Ejecutar(c);

        repo.AgregarCliente(c);
        return true;
    }
}


