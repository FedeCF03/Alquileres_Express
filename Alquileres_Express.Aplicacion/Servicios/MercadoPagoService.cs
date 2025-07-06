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
    IRepositorioAlquiler _repositorioAlquiler { get; set; }
    ServicioVerificarPago _servicioVerificarPago { get; set; }
    public MercadoPagoService(IConfiguration configuration, IRepositorioAlquiler repositorioAlquiler, ServicioVerificarPago servicioVerificarPago)
    {
        _servicioVerificarPago = servicioVerificarPago;
        _repositorioAlquiler = repositorioAlquiler;
        MercadoPagoConfig.AccessToken = "TEST-2709845014061287-060518-dfd5917bcf575f80fc7e47d5e16eae72-769910256";
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
                Success = "https://localhost:5153/success",
                Failure = "https://localhost:5153/failure",
            },
            AutoReturn = "approved",

        };
        var client = new PreferenceClient();

        Preference preference = await client.CreateAsync(request);
        _servicioVerificarPago.AgregarPagoPendiente(new PagoPendiente(preference.Id, alquiler));
        return preference.SandboxInitPoint; // URL para redirigir al checkout

    }

}
