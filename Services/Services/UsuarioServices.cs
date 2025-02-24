using BibliotecaSánchezLobatoGael83.Context;
using BibliotecaSánchezLobatoGael83.Models.Domain;
using BibliotecaSánchezLobatoGael83.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaSánchezLobatoGael83.Services.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly ApplicationDbContext _context;
        public UsuarioServices(ApplicationDbContext context) 
        { 
            _context = context;
        }

        // Explicar por que da error cuando no esta el return
        public List<Usuario> ObtenerUsuarios()
        {
            try
            {
                //Obtencion de los usuarios de la base de datos
                List<Usuario> result = _context.Usuarios.Include(x => x.Roles).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }
        }

        public bool CrearUsuario(Usuario request)
        {
            try
            {
                Usuario usuario = new Usuario()
                {
                    Nombre = request.Nombre,
                    UserName = request.UserName,
                    Password = request.Password,
                    FKRol = request.FKRol,
                };

                _context.Usuarios.Add(usuario);
                int result = _context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error: "+ex.Message);
            }
        }

        public Usuario GetUsuarioById(int id)
        {
            try
            {
                Usuario result = _context.Usuarios.Find(id);
                //Usuario result = _context.Usuarios.FirstOrDefault(x => x.PkUsuario == id);
                return result;
            }
            catch (Exception ex)
            {

                throw new Exception("Sucedio un error: "+ex.Message);
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
                usuario.Password = request.Password;
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
                return _context.Roles.ToList(); // Obtiene todos los roles de la base de datos
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los roles: " + ex.Message);
            }
        }
    }
}
