using System;
using System.Linq;

namespace Alquileres_Express.Aplicacion.Servicios;

public class Filtro<T>
{
    public  bool Aplicar {get; set;} = false;
    private Predicate<T> Predicado { get; set; } = t => true;

    public List<T> Filtrar(List<T> lista)
    {
        return Aplicar ? [.. lista.FindAll(Predicado)] : lista;
    }



}