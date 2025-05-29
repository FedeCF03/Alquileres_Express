using System;
using System.Linq;

namespace Alquileres_Express.Aplicacion.Servicios;

public class Filtro<T>
{
    private Boolean Aplicar;
    private Func<T, bool> predicado;

    public List<T> Filtrar(List<T> lista)
    {
        return Aplicar ? lista.Where(predicado).ToList() : lista;
    }


}