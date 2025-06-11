using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Aplicacion.Validadores;

namespace Alquileres_Express.Aplicacion.CasosDeUso;

public class CasoDeUsoModificarPersonal(ValidadorUsuario validador, IRepositorioPersonal repo)
{
    public bool Ejecutar(Personal p, out List<string> errores)
    {
        errores = validador.Ejecutar(p);
        if (errores.Count > 0)
        {
            return false; // Si hay errores de validación, retorna false
        }
        try
        {
            return repo.ModificarPersonal(p);
        }
        catch (Exception ex)
        {
            errores.Add(ex.Message);
            return false;
        }
    }
}