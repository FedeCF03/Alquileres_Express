using Alquileres_Express.Aplicacion.CasosDeUso;
using Alquileres_Express.UI.Components;
using Microsoft.AspNetCore.Authentication.Cookies;
using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Repositorios.Context;
using Alquileres_Express.Repositorios.RepositoriosSQLite;
using Alquileres_Express.Aplicacion.Validadores;

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

builder.Services.AddTransient<CasoDeUsoRegistrarUsuario>();
builder.Services.AddTransient<CasoDeUsoListarUsuario>();
builder.Services.AddScoped<IRepositorioPersonal, RepositorioPersonal>();
builder.Services.AddScoped<IRepositorioCliente, RepositorioCliente>();
builder.Services.AddTransient<IRepositorioInmueble, RepositorioInmueble>();

builder.Services.AddTransient<CasoDeUsoAltaInmueble>().AddTransient<ValidadorInmueble>();
builder.Services.AddTransient<CasoDeUsoAltaUsuario>();
builder.Services.AddTransient<CasoDeUsoAltaUsuario>();
builder.Services.AddTransient<CasoDeUsoBajaInmueble>();
builder.Services.AddTransient<CasoDeUsoBajaUsuario>();
// builder.Services.AddTransient<CasoDeUsoCancelarAlquiler>();
// builder.Services.AddTransient<CasoDeUsoEditarPerfil>();
// builder.Services.AddTransient<CasoDeUsoEliminarInmueble>();
//builder.Services.AddTransient<CasoDeUsoListarUsuario>();
builder.Services.AddTransient<CasoDeUsoModificarInmueble>();

builder.Services.AddTransient<CasoDeUsoRegistrarUsuario>();
// builder.Services.AddTransient<CasoDeUsoVerPerfil>();
// builder.Services.AddTransient<CasoDeUsoEliminarInmueble>();
builder.Services.AddTransient<CasoDeUsoModificarInmueble>();


builder.Services.AddHttpContextAccessor();
builder.Services.AddCascadingAuthenticationState();
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
app.Run();

Crear.Inicializar();
app.Run();
