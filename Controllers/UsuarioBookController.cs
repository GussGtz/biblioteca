using BibliotecaSánchezLobatoGael83.Models;
using BibliotecaSánchezLobatoGael83.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BibliotecaSánchezLobatoGael83.Controllers
{
    public class UsuarioBookController : Controller
    {
        private readonly IUsuarioBookService _usuarioBookService;

        public UsuarioBookController(IUsuarioBookService usuarioBookService)
        {
            _usuarioBookService = usuarioBookService;
        }

        // Vista Index - Mostrar todos los usuarios con sus libros
        [CustomAuthorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var usuariosConLibros = _usuarioBookService.ObtenerUsuariosConLibros();
            return View(usuariosConLibros);
        }

        // Vista Details - Ver los detalles de un usuario y sus libros
        [CustomAuthorize(Roles = "Admin")]
        public IActionResult Details(int id)
        {
            var usuarioConLibros = _usuarioBookService.ObtenerDetallesUsuario(id);
            if (usuarioConLibros == null)
            {
                return NotFound();
            }
            return View(usuarioConLibros);
        }

        // Vista Create - Asignar libros a un usuario
        [CustomAuthorize(Roles = "Admin")]
        public IActionResult Create()
        {
            var usuarios = _usuarioBookService.ObtenerUsuarios();
            var libros = _usuarioBookService.ObtenerLibros();
            ViewBag.Usuarios = usuarios;
            ViewBag.Libros = libros;
            return View();
        }

        // Crear la relación entre usuario y libros seleccionados
        [HttpPost]
        [CustomAuthorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int usuarioId, int[] selectedBooks)
        {
            if (selectedBooks.Length > 0)
            {
                _usuarioBookService.CrearRelacion(usuarioId, selectedBooks);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // Vista Edit - Editar los libros de un usuario
        [CustomAuthorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var usuarioConLibros = _usuarioBookService.ObtenerDetallesUsuario(id);
            if (usuarioConLibros == null)
            {
                return NotFound();
            }

            ViewBag.Usuario = usuarioConLibros;
            ViewBag.Libros = _usuarioBookService.ObtenerLibros();
            return View(usuarioConLibros);
        }

        // Actualizar las relaciones
        [HttpPost]
        [CustomAuthorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int usuarioId, int[] selectedBooks)
        {
            _usuarioBookService.ActualizarRelacion(usuarioId, selectedBooks);
            return RedirectToAction(nameof(Details), new { id = usuarioId });
        }

        // Eliminar un libro de un usuario
        [HttpPost]
        [CustomAuthorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int usuarioId, int bookId)
        {
            _usuarioBookService.EliminarRelacion(usuarioId, bookId);
            return RedirectToAction(nameof(Details), new { id = usuarioId });
        }
    }
}
