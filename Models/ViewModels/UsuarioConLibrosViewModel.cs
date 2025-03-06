using System.Collections.Generic;
using BibliotecaSánchezLobatoGael83.Models.Domain;

namespace BibliotecaSánchezLobatoGael83.Models.ViewModels
{
    public class UsuarioConLibrosViewModel
    {
        // Propiedad para la clave foránea del usuario
        public int FKUsuario { get; set; }

        // Propiedad para el nombre del usuario
        public string Nombre { get; set; }

        // Lista de libros disponibles
        public List<Book> Libros { get; set; }

        // Lista de libros seleccionados por el usuario (puede ser una lista de IDs de libros)
        public List<int> SelectedBooks { get; set; }
    }
}
