using System;
using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;
using Alquileres_Express.Aplicacion.Validadores;
using Alquileres_Express.Repositorios.Context;
using Microsoft.EntityFrameworkCore;

namespace Alquileres_Express.Repositorios.RepositorioSQLite;

public class RepositorioAlquiler : IRepositorioAlquiler
{
    readonly Alquileres_ExpressContext _context = new Alquileres_ExpressContext();
    public void RegistrarAlquilerPresencial(String correo, Inmueble inmueble, DateTime fechaInicio, DateTime fechaFin, int numeroPersonal)
    {
        Cliente? cliente = _context.Clientes.FirstOrDefault(c => c.Correo.ToLower() == correo.ToLower());
        Personal? personal = _context.Personal.FirstOrDefault(p => p.NumeroPersonal == numeroPersonal);
        if (cliente == null)
            throw new InvalidOperationException("El correo no esta vinculado a ningun cliente.");
        if (personal == null)
            throw new InvalidOperationException("El número de personal no está vinculado a ningún miembro del personal.");

        double precio = calcularPrecio(fechaInicio, fechaFin, inmueble.Precio);
        Alquiler alquiler = new Alquiler(cliente, inmueble, fechaInicio, fechaFin, precio, personal.Nombre, personal.Apellido);
        
        RegistroDeLlave registro = generarRegistroDeLlave(inmueble, personal, cliente, alquiler);

        alquiler.Registro = registro;

        //Agrego el nuevo alquiler a la lista de alquileres de inmueble
        if (inmueble.Alquileres == null)
            inmueble.Alquileres = new List<Alquiler>();

        inmueble.Alquileres.Add(alquiler);

        //Marcar el inmueble como modificado
        _context.Entry(inmueble).State = EntityState.Modified;

        //Guardar los cambios en la base de datos
        _context.Alquileres.Add(alquiler);
        _context.SaveChanges();

    }

    private double calcularPrecio(DateTime fechaInicio, DateTime fechaFin, double monto)
    {
        int cantidadDias = (fechaFin - fechaInicio).Days;
        double precioTotal = cantidadDias * monto;
        return precioTotal;
    }

    private RegistroDeLlave generarRegistroDeLlave(Inmueble inmueble, Personal personal, Cliente cliente, Alquiler alquiler)
    {
        
        RegistroDeLlave registro = new RegistroDeLlave
        {   
            Alquiler = alquiler,
            Inmueble = inmueble,
            Cliente = cliente,
            PersonalEntrega = personal,
            FechayHoraRegistro = DateTime.Now
        };

        _context.Llaves.Add(registro);
        _context.SaveChanges();
        return registro;
    }
}
