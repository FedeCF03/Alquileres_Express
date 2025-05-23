public class Codigo(int codigoVerificacion, String? correo)
{
    public int CodigoVerificacion { get; set; } = codigoVerificacion;
    public String? Correo { get; set; } = correo;

    public int GetCodigo()
    {
        return CodigoVerificacion;
    }
    public String? GetCorreo()
    {
        return Correo;
    }
}