using BibliotecaGustavoGtz.Models.Domain;
using BibliotecaGustavoGtz.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BibliotecaGustavoGtz.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioServices _usuarioServices;

        public UsuarioController(IUsuarioServices usuarioServices)
        {
            _usuarioServices = usuarioServices;
        }

        public IActionResult Index()
        {
            var result = _usuarioServices.ObtenerUsuarios();
            return View(result);
        }

        [HttpGet]
        [CustomAuthorize(Roles = "Admin")]
        public IActionResult Crear()
        {
            // Obtiene la lista de roles y la asigna a ViewBag.Roles
            ViewBag.Roles = new SelectList(_usuarioServices.GetRoles(), "PkRol", "Nombre");
            return View();
        }

        [HttpPost]
        [CustomAuthorize(Roles = "Admin")]
        public IActionResult Crear(Usuario request)
        {
            // Elimina la validación del ModelState
            bool resultado = _usuarioServices.CrearUsuario(request);
            if (!resultado)
            {
                // Si no se pudo guardar, recarga la vista con los roles
                ViewBag.Roles = new SelectList(_usuarioServices.GetRoles(), "PkRol", "Nombre");
                return View(request);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        [CustomAuthorize(Roles = "Admin")]
        public IActionResult Editar(int id)
        {
            var usuario = _usuarioServices.GetUsuarioById(id);
            if (usuario == null) return NotFound();

            // Obtiene la lista de roles y la asigna a ViewBag.Roles
            ViewBag.Roles = new SelectList(_usuarioServices.GetRoles(), "PkRol", "Nombre", usuario.FKRol);
            return View(usuario);
        }

        [HttpPost]
        [CustomAuthorize(Roles = "Admin")]
        public IActionResult Editar(Usuario request)
        {
            // Elimina la validación del ModelState
            bool updated = _usuarioServices.EditarUsuario(request);
            if (!updated) return NotFound();

            return RedirectToAction("Index");
        }

        [HttpPost] // Cambia HttpPost a HttpDelete
        [CustomAuthorize(Roles = "Admin")]
        public IActionResult Eliminar(int id)
        {
            try
            {
                bool deleted = _usuarioServices.EliminarUsuario(id);
                if (!deleted)
                {
                    TempData["Message"] = "No se pudo eliminar el usuario.";
                }
                else
                {
                    TempData["Message"] = "Usuario eliminado correctamente.";
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Error al eliminar el usuario: " + ex.Message;
            }

            return RedirectToAction("Index");
        }
    }
}
