namespace Alquileres_Express.Aplicacion.Entidades;

public class Personal : Usuario
{
    public bool EsGerente { get; set; }
    public int NumeroPersonal { get; set; }

    public Personal(int id, string correo, string contraseña, string nombre, string apellido, string direccion, DateTime fechaNacimiento, bool esGerente, int numeroPersonal)
        : base(id, correo, contraseña, nombre, apellido, direccion, fechaNacimiento)
    {
        EsGerente = esGerente;
        NumeroPersonal = numeroPersonal;
    }


}
