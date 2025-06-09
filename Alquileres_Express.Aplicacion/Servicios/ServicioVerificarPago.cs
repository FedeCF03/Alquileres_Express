

using Alquileres_Express.Aplicacion.CasosDeUso.CasosDeUsoAlquiler;
using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Aplicacion.Servicios;
namespace Alquileres_Express.Aplicacion.Servicios;

public class ServicioVerificarPago(CasoDeUsoRegistrarAlquilerOnline casoDeUsoRegistrarAlquilerOnline, ServicioEnviarEmail servicioEnviarEmail)
{
    List<PagoPendiente> PagosPendientes { get; set; } = new();

    public bool VerificarPago(String idPago)
    {
        Console.WriteLine("Pago pendiente agregado. Total de pagos pendientes: " + PagosPendientes.Count);

        PagoPendiente? pagoEncontrado = PagosPendientes.FirstOrDefault(p => p.IdPago == idPago);
        if (pagoEncontrado == null)
        {
            Console.WriteLine("No se encontró el pago pendiente con el ID proporcionado.");
            return false;
        }
        else
        {
            Console.WriteLine("Lo encontre y lo saco.");
            PagosPendientes.Remove(pagoEncontrado);
            casoDeUsoRegistrarAlquilerOnline.Ejecutar(pagoEncontrado.alquiler);
            //servicioEnviarEmail.EnviarEmail(pagoEncontrado.alquiler.CorreoCliente, "Alquiler registrado exitosamente", "Su pago fue exitoso! Por favor contáctese", "");
            return true;
        }
    }

    public void AgregarPagoPendiente(PagoPendiente pagoPendiente)
    {
        Console.WriteLine("Agregando pago pendiente: " + pagoPendiente.IdPago);
        PagosPendientes.Add(pagoPendiente);
        Console.WriteLine("Pago pendiente agregado. Total de pagos pendientes: " + PagosPendientes.Count);
    }
}