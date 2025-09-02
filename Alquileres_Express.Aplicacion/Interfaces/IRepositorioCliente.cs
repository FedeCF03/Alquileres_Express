using Alquileres_Express.Aplicacion.Entidades;
namespace Alquileres_Express.Aplicacion.Interfaces;

public interface IRepositorioCliente
{
    public void AgregarCliente(Cliente c);
    public Boolean ModificarCliente(Cliente c);
    public void EliminarCliente(Cliente c);
    public Cliente? ObtenerClientePorId(int id);
    public Cliente ObtenerClientePorDNI(string dni);
    public Cliente? ObtenerClientePorMail(string mail);

    public int ObtenerCantidadDeClientesEntreFechas(DateTime fechaInicio, DateTime fechaFin);
    public List<Cliente> ObtenerClientes();
    public Cliente? ObtenerClientePorMailYContraseña(string mail, string contraseña);
    public bool SeRepiteDNI(Cliente cliente);

    public bool SeRepiteCorreo(Cliente cliente);
 
}