namespace Alquileres_Express.Aplicacion.CasosDeUso;

using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Aplicacion.Validadores;

public class CasoDeUsoRegistrarCliente(ValidadorUsuario validador, IRepositorioCliente repo)
{
    public bool Ejecutar(Cliente c)
    {
        validador.Ejecutar(c);
        repo.AgregarCliente(c);
        return true;
    }
}


