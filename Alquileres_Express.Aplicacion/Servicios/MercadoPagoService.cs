using MercadoPago.Config;
using MercadoPago.Client.Preference;
using MercadoPago.Resource.Preference;
using Microsoft.Extensions.Configuration;

public class MercadoPagoService
{
    public MercadoPagoService(IConfiguration configuration)
    {
        // Se recomienda usar IConfiguration para no hardcodear el token
        MercadoPagoConfig.AccessToken = "APP_USR-4758729501201277-052522-20570b3514929dcdd539c2ecd6ff1b30-2456261951";
    }

    public async Task<string> CrearPreferenciaAsync( string title, decimal price)

    {
        var request = new PreferenceRequest
        {
            Items = new List<PreferenceItemRequest>
            {
                new PreferenceItemRequest
                {
                    Title = title,
                    Quantity = 1,
                    UnitPrice = price,
                    CurrencyId = "ARS"
                }
            },
            BackUrls = new PreferenceBackUrlsRequest
            {
                Success = "https://localhost:5153/success/" ,
                Failure = "https://localhost:5153/failure",
                Pending = "https://localhost:5153/pending"
            },
            AutoReturn = "approved"
        };

        var client = new PreferenceClient();
        Preference preference = await client.CreateAsync(request);
        return preference.InitPoint; // URL para redirigir al checkout
    }
}
