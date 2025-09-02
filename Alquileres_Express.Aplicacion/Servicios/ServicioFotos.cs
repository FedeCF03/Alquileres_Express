using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;

namespace Alquileres_Express.Aplicacion.Servicios;

public class ServicioFotos(IRepositorioFoto repositorioFoto)
{
    private readonly IRepositorioFoto RepositorioFoto = repositorioFoto;
    public void PersistirFotos(List<Foto> fotos, int inmuebleId)
    {
        fotos.ForEach(foto => foto.InmuebleId = inmuebleId);
        RepositorioFoto.AgregarFotos(fotos);

    }
    public void PersistirFoto(Foto foto, int inmuebleId)
    {
        foto.InmuebleId = inmuebleId;
        RepositorioFoto.AgregarFoto(foto);
    }

    public static string DevolverPathDeLaFoto(String name)
    {
        return Path.Combine(DevolverPathDelDirectorio(), DevolverNuevoNombre(name));

    }
    public static string DevolverPathDelDirectorio()
    {
        return Path.GetFullPath(
            Path.Combine(
                Directory.GetCurrentDirectory(),
               "wwwroot", "images", "fotosInmuebles"));
    }

    public static string DevolverNuevoNombre(String nombreArchivo)
    {
        return Path.ChangeExtension(
                    Path.GetRandomFileName(),
                    Path.GetExtension(nombreArchivo));
    }
    public void EliminarFotosPorInmueble(int id)
    {
        RepositorioFoto.EliminarFotosPorInmueble(id);
    }

    public void EliminarFotosDelDirectorio(List<Foto>? fotos)
    {
    if (fotos == null)
        {
            return;
        }
        foreach (var foto in fotos)
        {
            var path = Path.Combine(DevolverPathDelDirectorio(), foto.Nombre);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}