using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;

namespace Alquileres_Express.Aplicacion.CasosDeUso;

public class CasoDeUsoCambiarContrasena(IRepositorioUsuario repositorioUsuario) : CasoDeUsoUsuario(repositorioUsuario)
{
    public void Ejecutar(String correo, String nuevaContrasena)
    {
        repositorioUsuario.CambiarContrasena(correo, nuevaContrasena);
    }
}