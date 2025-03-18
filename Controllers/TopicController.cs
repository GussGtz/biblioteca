using BibliotecaGustavoGtz.Models.Domain;
using BibliotecaGustavoGtz.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaGustavoGtz.Controllers
{
    public class TopicsController : Controller
    {
        private readonly ITopicServices _topicServices;

        public TopicsController(ITopicServices topicServices)
        {
            _topicServices = topicServices;
        }

        [CustomAuthorize(Roles = "Admin, User")]
        public IActionResult Index()
        {
            var topics = _topicServices.ObtenerTopics();
            return View(topics);
        }

        [HttpGet]
        [CustomAuthorize(Roles = "Admin, User")]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [CustomAuthorize(Roles = "Admin, User")]
        public IActionResult Crear(Topic topic)
        {
            if (ModelState.IsValid)
            {
                _topicServices.CrearTopic(topic);
                return RedirectToAction("Index");
            }
            return View(topic);
        }

        [HttpGet]
        [CustomAuthorize(Roles = "Admin, User")]
        public IActionResult Editar(int id)
        {
            var topic = _topicServices.GetTopicById(id);
            if (topic == null)
            {
                return NotFound();
            }
            return View(topic);
        }

        [HttpPost]
        [CustomAuthorize(Roles = "Admin, User")]
        public IActionResult Editar(Topic topic)
        {
            if (ModelState.IsValid)
            {
                _topicServices.EditarTopic(topic);
                return RedirectToAction("Index");
            }
            return View(topic);
        }

        [HttpPost]
        [CustomAuthorize(Roles = "Admin, User")]
        public IActionResult Eliminar(int id)
        {
            _topicServices.EliminarTopic(id);
            return RedirectToAction("Index");
        }
    }
}
