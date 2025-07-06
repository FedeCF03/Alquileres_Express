using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;
namespace Alquileres_Express.Aplicacion.CasosDeUso;

public class CasoDeUsoBuscarEmail(IRepositorioUsuario repositorioUsuario) : CasoDeUsoUsuario(repositorioUsuario)
{
    public bool Ejecutar(string email)
    {
        return repositorioUsuario.existeEmail(email);

    }
}