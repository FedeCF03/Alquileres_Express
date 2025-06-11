namespace Alquileres_Express.Aplicacion.CasosDeUso;
using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Enumerativo;
using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Aplicacion.Validadores;

public class CasoDeUsoEditarInmueble(IRepositorioInmueble RepoInmueble, ValidadorInmueble Validador)
{
    public bool Ejecutar(Inmueble inmueble, RolUsuario rolUsuario, out List<string> errores)
    {
        if (rolUsuario != RolUsuario.Gerente)
        {
            errores = [];
            errores.Add("Solo los administradores o gerentes pueden agregar inmuebles.");
            return false;
        }
        errores = Validador.Ejecutar(inmueble);
        if (errores.Count > 0)
        {
            return false;
        }
        if (inmueble.Nombre != null && RepoInmueble.SeRepiteNombre(inmueble))
        {
            errores.Add("Ya existe un inmueble con el mismo nombre.");
            return false;
        }
            RepoInmueble.ModificarInmueble(inmueble);
            return true;
 
    }

}
