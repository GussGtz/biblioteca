using BibliotecaSánchezLobatoGael83.Context;
using BibliotecaSánchezLobatoGael83.Models.Domain;
using BibliotecaSánchezLobatoGael83.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaSánchezLobatoGael83.Services.Services
{
    public class RolServices : IRolServices
    {
        private readonly ApplicationDbContext _context;

        public RolServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Rol> ObtenerRoles()
        {
            return _context.Roles.ToList();
        }

        public bool CrearRol(Rol rol)
        {
            try
            {
                _context.Roles.Add(rol);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Rol GetRolById(int id)
        {
            return _context.Roles.Find(id);
        }

        public bool EditarRol(Rol rol)
        {
            try
            {
                _context.Roles.Update(rol);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool EliminarRol(int id)
        {
            try
            {
                var rol = _context.Roles.Find(id);
                if (rol != null)
                {
                    _context.Roles.Remove(rol);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}