using Alquileres_Express.Aplicacion.Entidades;
namespace Alquileres_Express.Aplicacion.Interfaces;

public interface IRepositorioFoto
{
    public Foto ObtenerFotoPorId(int id);
    public void AgregarFoto(Foto foto);
    public void EliminarFoto(int id);
    public List<Foto> ObtenerTodasLasFotos();
    public List<Foto> ObtenerFotosPorInmueble(int idInmueble);

}

