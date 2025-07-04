using System;
using Alquileres_Express.Aplicacion.Entidades;

namespace Alquileres_Express.Aplicacion.Interfaces;

public interface IRepositorioLlave
{
    public List<RegistroDeLlave> ListarRegistroLlaves(int idAlquiler, bool? esEntrega);
    public void AñadirRegistroDeLlave(RegistroDeLlave registroDeLlave);
    public List<RegistroDeLlave> ListarTodosLosRegistrosDeLlaves();
}
