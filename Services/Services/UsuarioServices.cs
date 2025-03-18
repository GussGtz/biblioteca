using BibliotecaGustavoGtz.Context;
using BibliotecaGustavoGtz.Models.Domain;
using BibliotecaGustavoGtz.Services.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

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
            return _context.Usuarios.Include(x => x.Roles).ToList();
        }
        catch (Exception ex)
        {
            throw new Exception("Error al obtener usuarios: " + ex.Message);
        }
    }

    public bool CrearUsuario(Usuario request)
    {
        try
        {
            var hashedPassword = HashPassword(request.Password);
            Usuario usuario = new Usuario
            {
                Nombre = request.Nombre,
                UserName = request.UserName,
                Password = hashedPassword,
                FKRol = request.FKRol,
                Added_on = DateTime.Now
            };

            _context.Usuarios.Add(usuario);
            return _context.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al crear usuario: " + ex.Message);
        }
    }

    public string HashPassword(string password)
    {
        return _passwordHasher.HashPassword(null, password);
    }

    public Usuario Login(string username, string password)
    {
        try
        {
            var usuario = _context.Usuarios
                                  .Include(u => u.Roles) // Cargar la relación con Roles
                                  .FirstOrDefault(u => u.UserName.ToLower() == username.ToLower());

            if (usuario == null)
            {
                Console.WriteLine($"Usuario '{username}' no encontrado.");
                return null;
            }

            Console.WriteLine($"Usuario encontrado: {usuario.UserName}");
            Console.WriteLine($"Rol del usuario: {usuario.Roles?.Nombre ?? "Sin rol asignado"}");

            var result = _passwordHasher.VerifyHashedPassword(usuario, usuario.Password, password);
            if (result == PasswordVerificationResult.Success)
            {
                Console.WriteLine("Contraseña válida. Usuario autenticado.");
                return usuario;
            }
            else
            {
                Console.WriteLine("Contraseña incorrecta.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error en Login: " + ex.Message);
        }

        return null;
    }

    public Usuario GetUsuarioById(int id)
    {
        try
        {
            return _context.Usuarios.Include(u => u.Roles).FirstOrDefault(u => u.PkUsuario == id);
        }
        catch (Exception ex)
        {
            throw new Exception("Error al obtener usuario por ID: " + ex.Message);
        }
    }

    public bool EditarUsuario(Usuario request)
    {
        try
        {
            var usuario = _context.Usuarios.Find(request.PkUsuario);
            if (usuario == null) return false;

            usuario.Nombre = request.Nombre;
            usuario.UserName = request.UserName;
            usuario.FKRol = request.FKRol;

            _context.Usuarios.Update(usuario);
            return _context.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al editar usuario: " + ex.Message);
        }
    }

    public bool EliminarUsuario(int id)
    {
        try
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null) return false;

            _context.Usuarios.Remove(usuario);
            return _context.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al eliminar usuario: " + ex.Message);
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
            throw new Exception("Error al obtener roles: " + ex.Message);
        }
    }

    public void Register(Usuario usuario)
    {
        try
        {
            usuario.Password = HashPassword(usuario.Password);
            usuario.FKRol = usuario.FKRol > 0 ? usuario.FKRol : 2; // Rol por defecto si no se asigna
            usuario.Added_on = DateTime.Now;

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            Console.WriteLine("Usuario registrado exitosamente.");
        }
        catch (Exception ex)
        {
            throw new Exception("Error al registrar usuario: " + ex.Message);
        }
    }
}
