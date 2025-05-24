using System.Net.Mail;

namespace Alquileres_Express.Aplicacion.Servicios;

public static class ServicioEnviarEmail
{


    public static void EnviarEmailDobleAutenticacion(string email)
    {
        MailMessage? mensaje = new();

        try
        {
            using (mensaje)
            {
                mensaje.From = new MailAddress("alquileresexpresssender@gmail.com");
                mensaje.To.Add(email);
                mensaje.Subject = "Codigo de verificación";
                mensaje.Body = "Su código de verificación es: " + ServicioGenerarCodigo.GenerarCodigoAleatorio(); ;
                mensaje.IsBodyHtml = true;

                using (var smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new System.Net.NetworkCredential("alquileresexpresssender@gmail.com", "mxvf sllx pxmf nkdk");
                    smtp.EnableSsl = true;
                    smtp.Send(mensaje);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }

}