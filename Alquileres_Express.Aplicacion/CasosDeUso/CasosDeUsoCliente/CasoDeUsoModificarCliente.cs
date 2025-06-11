using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Aplicacion.Validadores;

namespace Alquileres_Express.Aplicacion.CasosDeUso;

    public class CasoDeUsoModificarCliente(ValidadorUsuario validador, IRepositorioCliente repo)
    {
        public Boolean Ejecutar(Cliente c)
        {
            validador.Ejecutar(c);
            return repo.ModificarCliente(c);
        }
    }
