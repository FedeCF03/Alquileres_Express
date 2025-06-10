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
    readonly Alquileres_ExpressContext _context = new Alquileres_ExpressContext();
    public void RegistrarAlquilerPresencial(String correo, int idInmueble, DateTime fechaInicio, DateTime fechaFin, int numeroPersonal)
    {
        Cliente? cliente = _context.Clientes.FirstOrDefault(c => c.Correo.ToLower() == correo.ToLower());
        Personal? personal = _context.Personal.FirstOrDefault(p => p.Id == numeroPersonal);
        Inmueble? inmueble = _context.Inmuebles.FirstOrDefault(i => i.Id == idInmueble);
        if (cliente == null)
            throw new InvalidOperationException("El correo no esta vinculado a ningun cliente.");
        if (personal == null)
            throw new InvalidOperationException("El número de personal no está vinculado a ningún miembro del personal.");
        if (inmueble == null)
            throw new InvalidOperationException("El número de personal no está vinculado a ningún miembro del personal.");

        // Registrar alquiler despues de pagar

        decimal precio = calcularPrecio(fechaInicio, fechaFin, inmueble.Precio);

    }

    private decimal calcularPrecio(DateTime fechaInicio, DateTime fechaFin, decimal? monto)
    {
        if (monto == null)
            throw new ArgumentException("El monto debe tener valor");
        int cantidadDias = (fechaFin - fechaInicio).Days;
        decimal precioTotal = (cantidadDias - 1) * monto.Value;//Se cobra un dia menos
        return precioTotal;
    }

    // private RegistroDeLlave generarRegistroDeLlave(Personal personal, int idCliente, int idAlquier)
    // {

    //     RegistroDeLlave registro = new RegistroDeLlave
    //     {
    //         AlquilerId = idAlquier,
    //         ClienteId = idCliente,
    //         PersonalEntrega = personal,
    //         FechayHoraRegistro = DateTime.Now
    //     };

    //     _context.Llaves.Add(registro);
    //     _context.SaveChanges();
    //     return registro;
    // }

    public void RegistrarPagoEnEfectivo(String correo, int idInmueble, DateTime fechaInicio, DateTime fechaFin, Personal personal, decimal precio)
    {
        Alquiler alquiler = new Alquiler(correo, idInmueble, fechaInicio, fechaFin, precio, personal.Nombre, personal.Apellido);
        alquiler.Pagado = true;
        _context.Alquileres.Add(alquiler);
        guardarAlquilerEnBaseDeDatos(correo, idInmueble, personal, alquiler);

    }

    private void guardarAlquilerEnBaseDeDatos(String correo, int idInmueble, Personal personal, Alquiler alquiler)
    {
        Cliente? cliente = _context.Clientes.FirstOrDefault(c => c.Correo.ToLower() == correo.ToLower());//Tiene que estar
        Inmueble? inmueble = _context.Inmuebles.FirstOrDefault(i => i.Id == idInmueble);//x2

        // RegistroDeLlave registro = generarRegistroDeLlave(inmueble, personal, cliente.Id, alquiler.Id);
        // alquiler.Registro = registro; 
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
        alquiler.Pagado = true;
        _context.Alquileres.Add(alquiler);
        _context.SaveChanges();

    }
    public void RegistrarAlquilerVirtual(Alquiler alquiler)
    {
        alquiler.Pagado = true;
        _context.Alquileres.Add(alquiler);
        _context.SaveChanges();

    }

    public List<Alquiler> ObtenerAlquileresPorCorreo(string correo)
    {
        return [.. _context.Alquileres.Where(a => a.CorreoCliente == correo)];
    }
    public List<Alquiler> ObtenerTodosLosAlquileres()
    {
        return [.. _context.Alquileres.ToList()];
    }

    public EstadoDeAlquiler GetEstadoDeAlquiler(int idAlquiler)
    {
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
        Alquiler? alquiler = _context.Alquileres.FirstOrDefault(a => a.Id == idAlquiler);
        if (alquiler == null)
            throw new InvalidOperationException("El alquiler no existe.");

        alquiler.Cancelado = true;
        _context.Entry(alquiler).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public List<Alquiler> ObtenerAlquilerPorId(int idAlquiler)
    {
        return [.. _context.Alquileres.Where(a => a.Id == idAlquiler)];
    }
}


