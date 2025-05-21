using Alquileres_Express.UI.Components;
using Alquileres_Express.Aplicacion.UseCases;
using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddTransient<RegistrarUsuarioUseCase>();
builder.Services.AddTransient<ListarUsuarioUseCase>();
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuarioMock>();


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

app.Run();
