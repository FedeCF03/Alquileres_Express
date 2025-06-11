using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Aplicacion.Validadores;

namespace Alquileres_Express.Aplicacion.CasosDeUso
{
    public class CasoDeUsoAltaPersonal(ValidadorUsuario validador, IRepositorioPersonal repo)
    {
        public bool Ejecutar(Personal p, out List<string> errores)
        {
            errores = validador.Ejecutar(p);
            if (errores.Count > 0)
                return false;
            try
            {
                validador.Ejecutar(p);
                repo.AgregarPersonal(p);
                return true;
            }
            catch (Exception ex)
            {
                errores.Add(ex.Message);
                return false;
            }
        }
    }
}