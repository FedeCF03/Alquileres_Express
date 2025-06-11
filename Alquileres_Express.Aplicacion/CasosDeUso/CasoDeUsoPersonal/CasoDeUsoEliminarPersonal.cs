// namespace Alquileres_Express.Aplicacion.CasosDeUso;
// using Alquileres_Express.Aplicacion.Entidades;
// using Alquileres_Express.Aplicacion.Interfaces;

// public class CasoDeUsoEliminarPersonal(IRepositorioPersonal _repositorioPersonal)
// {
//     public bool Ejecutar(int id)
//     {
//         if (id <= 0)
//         {
//             return false; // Retorna false si el ID es inválido
//         }
        
//         var personal = _repositorioPersonal.ObtenerPersonalPorId(id);
//         if (personal == null)
//         {
//             return false; // Retorna false si no se encuentra el personal
//         }
        
//         return _repositorioPersonal.EliminarPersonal(personal);
//     }
// }