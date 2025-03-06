using BibliotecaSánchezLobatoGael83.Context;
using BibliotecaSánchezLobatoGael83.Models.Domain;
using BibliotecaSánchezLobatoGael83.Services.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class UsuarioServices : IUsuarioServices
{
    private readonly ApplicationDbContext _context;
    private readonly PasswordHasher<Usuario> _passwordHasher;

    public UsuarioServices(ApplicationDbContext context)
    {
        _context = context;
        _passwordHasher = new PasswordHasher<Usuario>();
    }

    public List<Usuario> ObtenerUsuarios()
    {
        try
        {
            List<Usuario> result = _context.Usuarios.Include(x => x.Roles).ToList();
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception("Sucedió un error: " + ex.Message);
        }
    }

    public bool CrearUsuario(Usuario request)
    {
        try
        {
            // Hashear la contraseña antes de guardar
            var hashedPassword = HashPassword(request.Password);

            Usuario usuario = new Usuario()
            {
                Nombre = request.Nombre,
                UserName = request.UserName,
                Password = hashedPassword,  // Almacenar la contraseña hasheada
                FKRol = request.FKRol,
            };

            _context.Usuarios.Add(usuario);
            int result = _context.SaveChanges();
            return result > 0;
        }
        catch (Exception ex)
        {
            throw new Exception("Sucedió un error: " + ex.Message);
        }
    }

    // Método para obtener el hash de la contraseña
    public string HashPassword(string password)
    {
        return _passwordHasher.HashPassword(null, password);
    }

    // Método para verificar la contraseña al iniciar sesión
    public Usuario Login(string username, string password)
    {
        // Incluye la entidad Rol relacionada
        var usuario = _context.Usuarios
                              .Include(u => u.Roles)  // Asegúrate de que la propiedad de navegación sea "Roles"
                              .FirstOrDefault(u => u.UserName == username);

        if (usuario != null)
        {
            var result = _passwordHasher.VerifyHashedPassword(usuario, usuario.Password, password);

            if (result == PasswordVerificationResult.Success)
            {
                return usuario;  // Devuelve el usuario con el rol incluido
            }
        }

        return null;  // Usuario o contraseña incorrectos
    }

    public Usuario GetUsuarioById(int id)
    {
        try
        {
            Usuario result = _context.Usuarios.Find(id);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception("Sucedió un error: " + ex.Message);
        }
    }

    public bool EditarUsuario(Usuario request)
    {
        try
        {
            Usuario usuario = _context.Usuarios.Find(request.PkUsuario);
            if (usuario == null) return false;

            usuario.Nombre = request.Nombre;
            usuario.UserName = request.UserName;
            usuario.FKRol = request.FKRol;

            _context.Usuarios.Update(usuario);
            return _context.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            throw new Exception("Sucedió un error: " + ex.Message);
        }
    }

    public bool EliminarUsuario(int id)
    {
        try
        {
            Usuario usuario = _context.Usuarios.Find(id);
            if (usuario == null) return false;

            _context.Usuarios.Remove(usuario);
            return _context.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            throw new Exception("Sucedió un error: " + ex.Message);
        }
    }

    public List<Rol> GetRoles()
    {
        try
        {
            return _context.Roles.ToList();
        }
        catch (Exception ex)
        {
            throw new Exception("Error al obtener los roles: " + ex.Message);
        }
    }

    public void Register(Usuario usuario)
    {
        usuario.FKRol = 2;
        usuario.Added_on = DateTime.Now;

        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
    }
}
