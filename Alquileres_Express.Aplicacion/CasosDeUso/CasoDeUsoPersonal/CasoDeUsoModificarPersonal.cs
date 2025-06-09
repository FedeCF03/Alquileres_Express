using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Aplicacion.Validadores;

namespace Alquileres_Express.Aplicacion.CasosDeUso;

    public class CasoDeUsoModificarPersonal(ValidadorUsuario validador, IRepositorioPersonal repo)
    {
        public Boolean Ejecutar(Personal p)
        {
            validador.Ejecutar(p);
            return repo.ModificarPersonal(p);
        }
    }
