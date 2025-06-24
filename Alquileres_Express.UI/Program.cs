using Alquileres_Express.Aplicacion.CasosDeUso;
using Alquileres_Express.UI.Components;
using Microsoft.AspNetCore.Authentication.Cookies;
using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Repositorios.Context;
using Alquileres_Express.Repositorios.RepositoriosSQLite;
using Alquileres_Express.Aplicacion.Validadores;
using Alquileres_Express.Aplicacion.Servicios;
using Alquileres_Express.Repositorio;

using Microsoft.Extensions.FileProviders;
using Alquileres_Express.Repositorios.RepositorioSQLite;
using Alquileres_Express.Aplicacion.CasosDeUso.CasosDeUsoAlquiler;
using Alquileres_Express.Aplicacion.CasosDeUso.CasosDeUsoPagarEfectivo;


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
    options.LoginPath = "/";

});
builder.Services.AddAuthorization();


builder.Services
    .AddTransient<CasoDeUsoListarCLiente>()
    .AddScoped<IRepositorioUsuario, RepositorioUsuario>()
    .AddTransient<CasoDeUsoListarUsuarios>()
    .AddTransient<CasoDeUsoListarRestringido>()

    .AddTransient<CasoDeUsoAltaCliente>()
    .AddTransient<CasoDeUsoBuscarCliente>()
    .AddTransient<CasoDeUsoModificarCliente>()
    .AddTransient<CasoDeUsoBajaInmueble>()
    .AddTransient<CasoDeUsoListarInmuebles>()
    .AddTransient<CasoDeUsoEditarInmueble>()
    .AddTransient<CasoDeUsoBuscarClientePorId>()

    .AddTransient<CasoDeUsoModificarInmueble>()
    .AddTransient<CasoDeUsoAltaInmueble>()

    .AddTransient<CasoDeUsoEliminarInmueble>()
    .AddTransient<CasoDeUsoObtenerInmueble>()
    .AddTransient<CasoDeUsoVerInmueble>()

    .AddTransient<CasoDeUsoAltaPersonal>()
    .AddTransient<CasoDeUsoModificarPersonal>()
    .AddTransient<CasoDeUsoActualizarEstadoDobleAutenticacion>()
    .AddTransient<CasoDeUsoBuscarPersonal>()
    .AddTransient<CasoDeUsoValidarCodigoDeSeguridad>()
    .AddTransient<CasoDeUsoRegistrarCliente>()
    .AddTransient<CasoDeUsoObtenerTodosLosAlquileres>()
    .AddTransient<CasoDeUsoObtenerAlquileresPorCorreo>()
    .AddTransient<CasoDeUsoAlquilerGetEstadoDeAlquiler>()
    .AddTransient<CasoDeUsoBuscarPersonalPorId>()
    .AddTransient<CasoDeUsoAscenderAGerente>()

    .AddTransient<CasoDeUsoBuscarClientePorCorreo>()
    .AddTransient<CasoDeUsoBuscarPersonalPorCorreo>()


    .AddScoped<IRepositorioPersonal, RepositorioPersonal>()
    .AddScoped<IRepositorioCliente, RepositorioCliente>()
    .AddScoped<IRepositorioInmueble, RepositorioInmueble>()
    .AddScoped<IRepositorioFoto, RepositorioFoto>()
    .AddScoped<IRepositorioInmueble, RepositorioInmueble>()
    .AddSingleton<IRepositorioAlquiler, RepositorioAlquiler>()
    .AddScoped<IRepositorioLlave, RepositorioLlave>()
    .AddTransient<CasoDeUsoListarLlaves>()
    .AddTransient<CasoDeUsoPersonalDescenderGerente>()
    .AddTransient<CasoDeUsoEliminarPersonal>()
    .AddTransient<CasoDeUsoRegistrarAlquilerPresencial>()
    .AddTransient<CasoDeUsoRegistrarEntregaPresencial>()
    .AddScoped<CasoDeUsoPagarEfectivo>()
    .AddSingleton<CasoDeUsoRegistrarAlquilerOnline>()
    .AddTransient<CasoDeUsoRegistrarAlquilerPresencial>()
    .AddTransient<CasoDeUsoPagarEfectivo>()
    .AddSingleton<CasoDeUsoRegistrarAlquilerOnline>()
    .AddTransient<ValidadorAlquiler>()
    .AddTransient<ServicioEnviarEmail>()
    .AddTransient<FiltroDeInmueblesService>()
    .AddTransient<ServicioGenerarCodigo>()
    .AddTransient<ValidadorInmueble>()
    .AddTransient<ValidadorUsuario>()
    .AddTransient<CasoDeUsoObtenerAlquilerPorId>()
    .AddHttpContextAccessor()
    .AddCascadingAuthenticationState()
    .AddTransient<ServicioFotos>()
    .AddTransient<CasoDeUsoAlquilerCancelarAlquiler>()
    .AddSingleton<ServicioVerificarPago>()
    .AddSingleton<MercadoPagoService>();
builder.WebHost.UseStaticWebAssets();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

Crear.Inicializar();
app.Run();
