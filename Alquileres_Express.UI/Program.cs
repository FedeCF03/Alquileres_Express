using Alquileres_Express.Aplicacion.CasosDeUso;
using Alquileres_Express.UI.Components;
using Microsoft.AspNetCore.Authentication.Cookies;
using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Repositorios.Context;
using Alquileres_Express.Repositorios.RepositoriosSQLite;
using Alquileres_Express.Aplicacion.Validadores;
using Alquileres_Express.Aplicacion.Servicios;
using Alquileres_Express.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
{
    options.Cookie.Name = "cookie_auth";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    options.SlidingExpiration = true;
    options.AccessDeniedPath = "/";
    options.LoginPath = "/Principal";

});

builder.Services.AddTransient<CasoDeUsoRegistrarUsuario>().
    AddTransient<CasoDeUsoListarUsuario>()

    .AddTransient<CasoDeUsoAltaCliente>()
    .AddTransient<CasoDeUsoBuscarCliente>()

    .AddTransient<CasoDeUsoAltaInmueble>()
    .AddTransient<CasoDeUsoBajaInmueble>()
    .AddTransient<CasoDeUsoListarInmuebles>()
    .AddTransient<CasoDeUsoModificarInmueble>()
    .AddTransient<CasoDeUsoEliminarInmueble>()
    .AddTransient<CasoDeUsoObtenerInmueble>()
    .AddTransient<CasoDeUsoVerInmueble>()

    .AddTransient<CasoDeUsoAltaPersonal>()
    .AddTransient<CasoDeUsoActualizarEstadoDobleAutenticacion>()
    .AddTransient<CasoDeUsoBuscarPersonal>()
    .AddTransient<CasoDeUsoValidarCodigoDeSeguridad>()
    .AddTransient<CasoDeUsoRegistrarCliente>()
  
    .AddScoped<IRepositorioPersonal, RepositorioPersonal>()
    .AddScoped<IRepositorioCliente, RepositorioCliente>()
    .AddScoped<IRepositorioInmueble, RepositorioInmueble>()
    .AddScoped<IRepositorioFoto, RepositorioFoto>()
    .AddScoped<IRepositorioInmueble, RepositorioInmueble>()

    .AddTransient<ServicioEnviarEmail>()
    .AddTransient<FiltroDeInmueblesService>()
    .AddTransient<MercadoPagoService>()
    .AddTransient<ServicioGenerarCodigo>()
    .AddTransient<ValidadorInmueble>()
    .AddTransient<ValidadorUsuario>()
    .AddHttpContextAccessor()
    .AddCascadingAuthenticationState();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.UseAuthentication();
app.UseAuthorization();

builder.Services.AddAuthorization();

Crear.Inicializar();
app.Run();
