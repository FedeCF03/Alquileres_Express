using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Aplicacion.Validadores;

namespace Alquileres_Express.Aplicacion.CasosDeUso
{
    public class CasoDeUsoAltaPersonal(ValidadorUsuario validador, IRepositorioPersonal repo)
    {
        public void Ejecutar(Personal p)
        {
            validador.Ejecutar(p);
            repo.AgregarPersonal(p);
        }
    }
}