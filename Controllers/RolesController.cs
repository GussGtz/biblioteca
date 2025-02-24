using BibliotecaSánchezLobatoGael83.Models.Domain;
using BibliotecaSánchezLobatoGael83.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaSánchezLobatoGael83.Controllers
{
    public class RolesController : Controller
    {
        private readonly IRolServices _rolServices;

        public RolesController(IRolServices rolServices)
        {
            _rolServices = rolServices;
        }

        public IActionResult Index()
        {
            var roles = _rolServices.ObtenerRoles();
            return View(roles);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Rol rol)
        {
            if (ModelState.IsValid)
            {
                _rolServices.CrearRol(rol);
                return RedirectToAction("Index");
            }
            return View(rol);
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var rol = _rolServices.GetRolById(id);
            if (rol == null)
            {
                return NotFound();
            }
            return View(rol);
        }

        [HttpPost]
        public IActionResult Editar(Rol rol)
        {
            if (ModelState.IsValid)
            {
                _rolServices.EditarRol(rol);
                return RedirectToAction("Index");
            }
            return View(rol);
        }

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            _rolServices.EliminarRol(id);
            return RedirectToAction("Index");
        }
    }
}