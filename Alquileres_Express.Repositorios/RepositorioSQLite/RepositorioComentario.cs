namespace Alquileres_Express.Aplicacion.Interfaces
{
    using Alquileres_Express.Aplicacion.Entidades;
    using Alquileres_Express.Aplicacion.Enumerativo;
    using Alquileres_Express.Repositorios.Context;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class RepositorioComentario : IRepositorioComentario
    {
        public bool AgregarComentario(Comentario comentario)
        {
            using var db = new Alquileres_ExpressContext();

                db.Comentarios.Add(comentario);
                db.SaveChanges();
                return true;
    
            
        }

        public Task<bool> EditarComentarioAsync(Comentario comentario)
        {
            using var db = new Alquileres_ExpressContext();
            var existingComentario = db.Comentarios.Find(comentario.Id);
            if (existingComentario != null)
            {
                existingComentario.Texto = comentario.Texto;
                existingComentario.Fecha = comentario.Fecha;
                existingComentario.PersonalId = comentario.PersonalId;
                existingComentario.ClienteId = comentario.ClienteId;
                db.SaveChanges();
            }
            return Task.FromResult(existingComentario != null);
        }

        public Task<bool> EliminarComentarioAsync(int comentarioId)
        {
            using var db = new Alquileres_ExpressContext();
            var comentario = db.Comentarios.Find(comentarioId);
            if (comentario != null)
            {
                db.Comentarios.Remove(comentario);
                db.SaveChanges();
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public Task<List<Comentario>> ObtenerComentariosPorUsuarioIdAsync(int usuarioId, RolUsuario rolUsuario)
        {
            using var db = new Alquileres_ExpressContext();
            List<Comentario>? comentarios;
            if (rolUsuario == RolUsuario.Cliente)
            {
                comentarios = db.Comentarios.Include(c => c.Respuestas).Where(c => c.ClienteId == usuarioId).ToList();
            }
            else
            {
                comentarios = db.Comentarios.Include(c => c.Respuestas).Where(c => c.PersonalId == usuarioId).ToList();
            }
            return Task.FromResult(comentarios)!;

        }

        public Task<List<Comentario>> ObtenerComentariosPorInmuebleIdAsync(int inmuebleId)
        {
            using var db = new Alquileres_ExpressContext();
            return Task.FromResult(db.Comentarios.Include(c => c.Respuestas).Where(c => c.InmuebleId == inmuebleId).ToList());
        }
    }
}