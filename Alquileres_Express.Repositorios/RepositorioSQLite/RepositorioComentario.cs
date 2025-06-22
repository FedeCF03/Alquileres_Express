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

        public bool EditarComentario(Comentario comentario)
        {
            using var db = new Alquileres_ExpressContext();
            var existingComentario = db.Comentarios.Find(comentario.Id);
            if (existingComentario != null)
            {
                existingComentario.Texto = comentario.Texto;
                existingComentario.Fecha = comentario.Fecha;
                existingComentario.Editado = true;
                db.SaveChanges();
            }
            return existingComentario != null;
        }

        public async Task<bool> EliminarComentarioAsync(int comentarioId)
        {
            using var db = new Alquileres_ExpressContext();
            var comentario = await db.Comentarios.FindAsync(comentarioId);
            if (comentario != null)
            {
                db.Comentarios.Remove(comentario);
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public List<Comentario> ObtenerComentariosPorUsuarioIdAsync(int usuarioId, RolUsuario rolUsuario)
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
            return comentarios;

        }

        public List<Comentario> ObtenerComentariosPorInmuebleIdAsync(int inmuebleId)
        {
            using var db = new Alquileres_ExpressContext();
            return db.Comentarios.Include(c => c.Respuestas).Where(c => c.InmuebleId == inmuebleId).ToList();
        }

        public List<Comentario> BuscarRespuestasPorComentarioIdAsync(int comentarioId)
        {
            using var db = new Alquileres_ExpressContext();
            return db.Comentarios
                .Include(c => c.Respuestas)
                .Where(c => c.ComentarioId == comentarioId)
                .ToList();
        }
    }
}