using Alquileres_Express.Aplicacion.Enumerativo;

namespace Alquileres_Express.Aplicacion.Entidades;

public class ContraseñaPendiente
{
    public string CorreoElectronico { get; set; } = "";
    public string Codigo { get; set; }
    public string ContraseñaNueva { get; set; } = "";

}