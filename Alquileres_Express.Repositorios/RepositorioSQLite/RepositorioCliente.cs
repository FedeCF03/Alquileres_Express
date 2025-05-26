namespace Alquileres_Express.Repositorios.RepositoriosSQLite;

using Alquileres_Express.Aplicacion.Entidades;
using Alquileres_Express.Aplicacion.Interfaces;
using System.Collections.Generic;

public class RepositorioCliente : IRepositorioCliente
{
    public void EliminarCliente(Cliente c)
    {
        throw new NotImplementedException();
        
    }

    public void ModificarCliente(Cliente c)
    {
        throw new NotImplementedException();
    }

    public Cliente ObtenerClientePorId(int id)
    {
        throw new NotImplementedException();
    }

    public List<Cliente> ObtenerClientes()
    {
        throw new NotImplementedException();
    }

    public void RegistrarCliente(Cliente c)
    {
        throw new NotImplementedException();
    }


    public void AgregarCliente(Cliente c)
    {

    }

    public Cliente ObtenerClientePorDNI(string dni)
    {
        throw new NotImplementedException();
    }

    public Cliente ObtenerClientePorMail(string mail)
    {
        throw new NotImplementedException();
    }
}