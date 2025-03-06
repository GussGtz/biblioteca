using BibliotecaSánchezLobatoGael83.Models;
using BibliotecaSánchezLobatoGael83.Models.Domain;
using System.Collections.Generic;

namespace BibliotecaSánchezLobatoGael83.Services
{
    public interface IUsuarioBookService
    {
        List<Usuario> ObtenerUsuariosConLibros();
        Usuario ObtenerDetallesUsuario(int usuarioId);
        List<Usuario> ObtenerUsuarios();
        List<Book> ObtenerLibros();
        void CrearRelacion(int usuarioId, int[] bookIds);
        void ActualizarRelacion(int usuarioId, int[] bookIds);
        void EliminarRelacion(int usuarioId, int bookId);
        Task<int> CountUsuarioBooksAsync();
    }
}
