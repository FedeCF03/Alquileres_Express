using Alquileres_Express.Aplicacion.Entidades;

namespace Alquileres_Express.Aplicacion.Validadores;

public class ValidadorUsuario
{
    public bool Ejecutar(Usuario usuario)
    {
        //Validar campos
        if (!ValidarCampos(usuario))
            return false;
        //Validar contraseña
        if (usuario.Contraseña.Length < 6)
            return false;

        //Validar edad
        TimeSpan distanciaEntreFechas = DateTime.Now - usuario.FechaNacimiento;
        if (distanciaEntreFechas.TotalDays < 6570) // 6570 días son aproximadamente 18 años
            return false;
        return true;
    }

    private bool ValidarCampos(Usuario u)
    {
        if (string.IsNullOrWhiteSpace(u.Nombre) || string.IsNullOrWhiteSpace(u.Apellido) ||
            string.IsNullOrWhiteSpace(u.Correo) || string.IsNullOrWhiteSpace(u.Contraseña) ||
            string.IsNullOrWhiteSpace(u.Direccion))
        {
            return false;
        }
        return true;
    }
}
