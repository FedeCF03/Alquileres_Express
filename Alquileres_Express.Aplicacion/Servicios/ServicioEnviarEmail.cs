using System.Net.Mail;

namespace Alquileres_Express.Aplicacion.Servicios;

public class ServicioEnviarEmail
{


    public void EnviarEmail(string email, string subject , string body , string cod)
    {
        MailMessage? mensaje = new();
        try
        {
            using (mensaje)
            {
                mensaje.From = new MailAddress("alquileresexpresssender@gmail.com");
                mensaje.To.Add(email);
                mensaje.Subject = subject;
                mensaje.Body = body + cod;
                mensaje.IsBodyHtml = true;

                using var smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new System.Net.NetworkCredential("alquileresexpresssender@gmail.com", "mxvf sllx pxmf nkdk");
                smtp.EnableSsl = true;
                smtp.Send(mensaje);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

}