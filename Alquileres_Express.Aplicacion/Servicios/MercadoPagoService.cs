using MercadoPago.Config;
using MercadoPago.Client.Preference;
using MercadoPago.Resource.Preference;
using Microsoft.Extensions.Configuration;
using System;
using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Servicios;

public class MercadoPagoService
{
    ServicioEnviarEmail _servicioEnviarEmail { get; set; } 
     IRepositorioAlquiler _repositorioAlquiler{ get; set; }
    public MercadoPagoService(IConfiguration configuration, IRepositorioAlquiler repositorioAlquiler, ServicioEnviarEmail servicioEnviarEmail)
    {   
        _repositorioAlquiler = repositorioAlquiler;
        _servicioEnviarEmail = servicioEnviarEmail;
        MercadoPagoConfig.AccessToken = "APP_USR-4758729501201277-052522-20570b3514929dcdd539c2ecd6ff1b30-2456261951";
    }

    public async Task<string> CrearPreferenciaAsync(string titulo, Alquiler alquiler)

    {
        var request = new PreferenceRequest
        {
            Items = new List<PreferenceItemRequest>
            {

                new PreferenceItemRequest
                {
                    Title = titulo,
                    Quantity = 1,
                    UnitPrice = alquiler.Precio,
                    CurrencyId = "ARS"
                }
            },
            BackUrls = new PreferenceBackUrlsRequest
            {
                Success = RegistrarCompra(alquiler),
                Failure = "https://localhost:5153/failure",
                Pending = "https://localhost:5153/pending"
            },
            AutoReturn = "approved"
        };
        var client = new PreferenceClient();
        Preference preference = await client.CreateAsync(request);
        return preference.InitPoint; // URL para redirigir al checkout
    }

    private string RegistrarCompra( Alquiler alquiler)
    {

        _repositorioAlquiler.RegistrarAlquilerVirtual(alquiler);
        _servicioEnviarEmail.EnviarEmail(alquiler.CorreoCliente, "Alquiler registrado exitosamente","Su pago fue exitoso! Por favor contáctese","" );
        return "https://localhost:5153/";
    }
}
