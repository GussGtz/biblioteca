using BibliotecaSánchezLobatoGael83.Models.Domain;
using BibliotecaSánchezLobatoGael83.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BibliotecaSánchezLobatoGael83.Controllers
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
        public IActionResult Crear()
        {
            ViewBag.Roles = new SelectList(_usuarioServices.ObtenerRoles(), "PkRol", "Nombre");
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Usuario request)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Roles = new SelectList(_usuarioServices.ObtenerRoles(), "PkRol", "Nombre");
                return View(request);
            }

            _usuarioServices.CrearUsuario(request);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var usuario = _usuarioServices.GetUsuarioById(id);
            if (usuario == null) return NotFound();

            ViewBag.Roles = new SelectList(_usuarioServices.ObtenerRoles(), "PkRol", "Nombre", usuario.FKRol);
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Editar(Usuario request)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Roles = new SelectList(_usuarioServices.ObtenerRoles(), "PkRol", "Nombre", request.FKRol);
                return View(request);
            }

            bool updated = _usuarioServices.EditarUsuario(request);
            if (!updated) return NotFound();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            bool deleted = _usuarioServices.EliminarUsuario(id);
            if (!deleted) return NotFound();

            return RedirectToAction("Index");
        }
    }
}
