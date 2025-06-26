using System;
using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Enumerativo;
using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Aplicacion.Validadores;
using Alquileres_Express.Repositorios.Context;
using Microsoft.EntityFrameworkCore;

namespace Alquileres_Express.Repositorios.RepositorioSQLite;

public class RepositorioAlquiler : IRepositorioAlquiler
{
    public void RegistrarAlquilerPresencial(String correo, int idInmueble, DateTime fechaInicio, DateTime fechaFin, int numeroPersonal)
    {
        using Alquileres_ExpressContext _context = new();
        Cliente? cliente = _context.Clientes.FirstOrDefault(c => c.Correo.ToLower() == correo.ToLower());
        Personal? personal = _context.Personal.FirstOrDefault(p => p.Id == numeroPersonal);
        Inmueble? inmueble = _context.Inmuebles.FirstOrDefault(i => i.Id == idInmueble);
        if (cliente == null)
            throw new InvalidOperationException("El correo no esta vinculado a ningun cliente.");
        if (personal == null)
            throw new InvalidOperationException("El número de personal no está vinculado a ningún miembro del personal.");
        if (inmueble == null)
            throw new InvalidOperationException("El número de personal no está vinculado a ningún miembro del personal.");


    }

    private decimal calcularPrecio(DateTime fechaInicio, DateTime fechaFin, decimal? monto)
    {
        using Alquileres_ExpressContext _context = new();
        if (monto == null)
            throw new ArgumentException("El monto debe tener valor");
        int cantidadDias = (fechaFin - fechaInicio).Days;
        decimal precioTotal = (cantidadDias - 1) * monto.Value;//Se cobra un dia menos
        return precioTotal;
    }

    

    public void RegistrarPagoEnEfectivo(Alquiler alquiler, int idInmueble, DateTime fechaInicio, DateTime fechaFin)
    {
        using Alquileres_ExpressContext _context = new();
        if (!EstaDisponible(idInmueble, fechaInicio, fechaFin))
            throw new InvalidOperationException("El inmueble no está disponible para el período seleccionado.");
        {
            alquiler.Pagado = true;
            guardarAlquilerEnBaseDeDatos(alquiler);
        }
    }

    public bool EstaDisponible(int inmuebleId, DateTime fechaInicio, DateTime fechaFin)
    {
        using Alquileres_ExpressContext _context = new();
        var alquileresDelInmueble = _context.Alquileres
            .Where(a => a.InmuebleId == inmuebleId)
            .ToList();

        var fechasReservadas = alquileresDelInmueble
            .Where(a => !a.Cancelado && a.Pagado && !a.GetEstadoDeAlquiler().Equals(EstadoDeAlquiler.Terminado))
            .Select(a => new RangoDeFechas(a.FechaDeInicio, a.FechaDeFin.AddDays(-1)))
            .ToList();

        return !fechasReservadas.Any(rango => rango.SeSuperponeCon(new RangoDeFechas(fechaInicio, fechaFin)));
    }


    private void guardarAlquilerEnBaseDeDatos(Alquiler alquiler)
    {
        using Alquileres_ExpressContext _context = new();
        Inmueble? inmueble = _context.Inmuebles.FirstOrDefault(i => i.Id == alquiler.InmuebleId);//x2

        if (inmueble.Alquileres == null)
            inmueble.Alquileres = new List<Alquiler>();

        inmueble.Alquileres.Add(alquiler);

        //Marcar el inmueble como modificado
        _context.Entry(inmueble).State = EntityState.Modified;

        //Guardar los cambios en la base de datos
        _context.Alquileres.Add(alquiler);
        _context.SaveChanges();

    }


    public void pagarAlquilerMercadoPago(Alquiler alquiler)
    {
        using Alquileres_ExpressContext _context = new();
        alquiler.Pagado = true;
        _context.Alquileres.Add(alquiler);
        _context.SaveChanges();

    }
    public void RegistrarAlquilerVirtual(Alquiler alquiler)
    {
        using Alquileres_ExpressContext _context = new();
        alquiler.FechaDeInicio.AddHours(15);
        alquiler.Pagado = true;
        _context.Alquileres.Add(alquiler);
        _context.SaveChanges();

    }

    public List<Alquiler> ObtenerAlquileresPorCorreo(string correo)
    {
        using Alquileres_ExpressContext _context = new();
        return [.. _context.Alquileres.Include(a => a.RegistrosDeLlave).Where(a => a.CorreoCliente == correo)];
    }
    public List<Alquiler> ObtenerTodosLosAlquileres()
    {
        using Alquileres_ExpressContext _context = new();
        return [.. _context.Alquileres.Include(a => a.RegistrosDeLlave).ToList()];
    }

    public EstadoDeAlquiler GetEstadoDeAlquiler(int idAlquiler)
    {
        using Alquileres_ExpressContext _context = new();
        Alquiler? alquiler = _context.Alquileres.FirstOrDefault(a => a.Id == idAlquiler);

        if (alquiler.FechaDeFin < DateTime.Now)
        {
            return EstadoDeAlquiler.Terminado;
        }
        else if (alquiler.FechaDeInicio > DateTime.Now)
        {
            return EstadoDeAlquiler.Vigente;

        }

        return EstadoDeAlquiler.EnProceso;
    }

    public void cancelarAlquiler(int idAlquiler)
    {
        using Alquileres_ExpressContext _context = new();
        Alquiler? alquiler = _context.Alquileres.FirstOrDefault(a => a.Id == idAlquiler);
        if (alquiler == null)
            throw new InvalidOperationException("El alquiler no existe.");

        alquiler.Cancelado = true;
        _context.Entry(alquiler).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public List<Alquiler> ObtenerAlquilerPorId(int idAlquiler)
    {
        using Alquileres_ExpressContext _context = new();
        return [.. _context.Alquileres.Include(a => a.RegistrosDeLlave).Where(a => a.Id == idAlquiler)];
    }

    public decimal ObtenerValorDeAlquileresEntreFechas(DateTime fechaInicio, DateTime fechaFin)
    {
        using Alquileres_ExpressContext _context = new();
        decimal num = 0;
        num = _context.Alquileres.Where(a => a.FechaDeInicio >= fechaInicio && a.FechaDeFin <= fechaFin).Where(a => a.Pagado).Sum(a => a.Precio);
        return num;
    }

    public bool CalificarAlquiler(int idInmueble, int idCliente, Valoracion valoracion)
    {
        using Alquileres_ExpressContext _context = new();
        Inmueble? inmueble = _context.Inmuebles.Include(i => i.Valoraciones).FirstOrDefault(i => i.Id == idInmueble);


        if (inmueble == null)
            throw new InvalidOperationException("El inmueble no existe.");


        Valoracion? v = inmueble.Valoraciones.FirstOrDefault(v => v.ClienteId == idCliente);
        //Console.WriteLine("Valoracion: " + v.ClienteId + v.ApellidoCliente);
        if (v != null)
        {
            return false;
        }
        inmueble.Valoraciones.Add(valoracion);
        _context.Entry(inmueble).State = EntityState.Modified;
        _context.SaveChanges();
        return true;
    }
}


