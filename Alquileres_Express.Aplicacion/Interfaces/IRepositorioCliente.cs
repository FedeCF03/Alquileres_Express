using Alquileres_Express.Aplicacion.Entidades;
namespace Alquileres_Express.Aplicacion.Interfaces;

public interface IRepositorioCliente
{
    public void AgregarCliente(Cliente c);
    public void ModificarCliente(Cliente c);
    public void EliminarCliente(Cliente c);
    public Cliente ObtenerClientePorId(int id);
    public Cliente ObtenerClientePorDNI(string dni);
    public Cliente ObtenerClientePorMail(string mail);
    public List<Cliente> ObtenerClientes();
    public void RegistrarCliente(Cliente c);
    public Cliente ObtenerClientePorMailYContraseña(string mail, string contraseña);
}