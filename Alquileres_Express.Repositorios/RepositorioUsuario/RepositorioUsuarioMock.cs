namespace Alquileres_Express.Repositorios;

public class RepositorioUsuarioMock //: IRepositorioUsuario
{
    // private readonly List<Usuario> _listaUsuarios = new List<Usuario>()
    // {
    //     new Usuario(){ID = 1,
    //         correo = "maria@gmail.com",
    //         contraseña = "123456",
    //         nombre = "Maria",
    //         apellido = "Torres",
    //         direccion = "La plata",
    //         fechaNacimiento = new DateTime(2025, 5, 20)}
    // };

    static int _proximoId = 2;
    // private Usuario Clonar(Usuario u) 
    // {
    //     return new Usuario()
    //     {
    //         ID = u.ID,
    //         correo = u.correo,
    //         contraseña = u.contraseña,
    //         nombre = u.nombre,
    //         apellido = u.apellido,
    //         direccion = u.direccion,
    //         fechaNacimiento = u.fechaNacimiento
    //     };
    // }
    // public void RegistrarUsuario(Usuario u)
    // {
    //     var existe = _listaUsuarios.Any(aux => aux.correo == u.correo);

    //     if (!existe)
    //     {
    //         u.ID = _proximoId++;
    //         _listaUsuarios.Add(Clonar(u)); // Agrega solo si el correo está libre
    //     }
    //     else
    //     {
    //         // Opcional: lanzar una excepción o manejar el error
    //         throw new InvalidOperationException("El correo ya está registrado por otro usuario.");
    //     }
    // }

    // public List<Usuario> GetUsuarios()//Devuelve una copia de la lista de usuarios
    // {
    //     return _listaUsuarios.Select(u => Clonar(u)).ToList();
    // }
}