using BibliotecaGustavoGtz.Context;
using BibliotecaGustavoGtz.Models;
using BibliotecaGustavoGtz.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BibliotecaGustavoGtz.Services
{
    public class UsuarioBookService : IUsuarioBookService
    {
        private readonly ApplicationDbContext _context;

        public UsuarioBookService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CountUsuarioBooksAsync()
        {
            return await _context.UsuarioBooks.CountAsync();
        }

        public List<Usuario> ObtenerUsuariosConLibros()
        {
            return _context.Usuarios
                .Where(u => u.UsuarioBooks.Any())
                .ToList();
        }

        public Usuario ObtenerDetallesUsuario(int usuarioId)
        {
            return _context.Usuarios
                .Where(u => u.PkUsuario == usuarioId)
                .Include(u => u.UsuarioBooks)
                .ThenInclude(ub => ub.Book)
                .FirstOrDefault();
        }

        public List<Usuario> ObtenerUsuarios()
        {
            return _context.Usuarios.ToList();
        }

        public List<Book> ObtenerLibros()
        {
            return _context.Books.ToList();
        }

        public void CrearRelacion(int usuarioId, int[] bookIds)
        {
            foreach (var bookId in bookIds)
            {
                _context.UsuarioBooks.Add(new UsuarioBook
                {
                    FKUsuario = usuarioId,
                    FKBook = bookId
                });
            }
            _context.SaveChanges();
        }

        public void ActualizarRelacion(int usuarioId, int[] bookIds)
        {
            var relacionesExistentes = _context.UsuarioBooks
                .Where(ub => ub.FKUsuario == usuarioId)
                .ToList();

            // Eliminar las relaciones anteriores
            _context.UsuarioBooks.RemoveRange(relacionesExistentes);

            // Agregar las nuevas relaciones
            CrearRelacion(usuarioId, bookIds);
        }

        public void EliminarRelacion(int usuarioId, int bookId)
        {
            var relacion = _context.UsuarioBooks
                .FirstOrDefault(ub => ub.FKUsuario == usuarioId && ub.FKBook == bookId);

            if (relacion != null)
            {
                _context.UsuarioBooks.Remove(relacion);
                _context.SaveChanges();
            }
        }
    }
}
