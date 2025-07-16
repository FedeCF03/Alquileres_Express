using System;
using System.Collections.Generic;
namespace Alquileres_Express.Aplicacion.Entidades;
public class ContadorDeFrecuencias<TKey> : Dictionary<TKey, int>
where TKey : notnull
{
    // Incrementa la frecuencia de una clave
    public void Agregar(TKey clave)
    {
        if (this.ContainsKey(clave))
        {
            this[clave]++;
        }
        else
        {
            this[clave] = 1;
        }
    }

    // Permite agregar múltiples claves (por ejemplo, de una lista)
    public void AgregarRango(IEnumerable<TKey> claves)
    {
        foreach (var clave in claves)
        {
            Agregar(clave);
        }
    }

    // Devuelve la frecuencia de una clave, o 0 si no existe
    public int Frecuencia(TKey clave)
    {
        return this.TryGetValue(clave, out int conteo) ? conteo : 0;
    }
}