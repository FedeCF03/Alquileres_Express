
using Alquileres_Express.Aplicacion.CasosDeUso;
using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;
using BCrypt.Net;
using Microsoft.Extensions.DependencyInjection;
namespace Alquileres_Express.Aplicacion.Servicios;

public class ServicioCambiarContrasena
{
    private readonly IServiceProvider _serviceProvider;
    private List<ContraseñaPendiente> _pendientes = [];

    public ServicioCambiarContrasena(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public string Añadir(ContraseñaPendiente c)
    {
        if (_pendientes.Any(x => x.CorreoElectronico == c.CorreoElectronico))
            return "Ya existe una solicitud pendiente para este correo.";

        _pendientes.Add(c);
        return "Solicitud de cambio de contraseña añadida correctamente.";
    }

    public bool Verificar(ContraseñaPendiente c)
    {
        var pendiente = _pendientes.FirstOrDefault(x => x.CorreoElectronico == c.CorreoElectronico);
        if (pendiente == null || pendiente.Codigo != c.Codigo)
            return false;

        // Creamos un scope para obtener el servicio scoped de forma segura
        using var scope = _serviceProvider.CreateScope();
        var caso = scope.ServiceProvider.GetRequiredService<CasoDeUsoCambiarContrasena>();
        caso.Ejecutar(pendiente.CorreoElectronico, pendiente.ContraseñaNueva);

        _pendientes.Remove(pendiente);
        return true;
    }
}