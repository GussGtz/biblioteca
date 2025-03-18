using BibliotecaGustavoGtz.Models.Domain;
using BibliotecaGustavoGtz.Services;
using BibliotecaGustavoGtz.Services.Interfaces;
using BibliotecaGustavoGtz.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace BibliotecaGustavoGtz.Controllers
{
    public class CollectionsController : Controller
    {
        private readonly ICollectionService _collectionService;
        private readonly IAuthorService _authorService;
        private readonly ITopicServices _topicService;

        public CollectionsController(ICollectionService collectionService, IAuthorService authorService, ITopicServices topicService)
        {
            _collectionService = collectionService;
            _authorService = authorService;
            _topicService = topicService;
        }

        [CustomAuthorize(Roles = "Admin, User")]
        public async Task<IActionResult> Index()
        {
            var collections = await _collectionService.GetAllCollectionsAsync();
            return View(collections);
        }

        [CustomAuthorize(Roles = "Admin, User")]
        public async Task<IActionResult> Create()
        {
            ViewBag.Authors = new SelectList(await _authorService.GetAllAuthorsAsync(), "PkAuthor", "Name_author");
            ViewBag.Topics = new SelectList(_topicService.ObtenerTopics(), "PkTopic", "Name_topic");
            return View();
        }

        [HttpPost]
        [CustomAuthorize(Roles = "Admin, User")]
        public async Task<IActionResult> Create(Collection collection)
        {
                await _collectionService.AddCollectionAsync(collection);
                return RedirectToAction(nameof(Index));
        }

        [CustomAuthorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var collection = await _collectionService.GetCollectionByIdAsync(id);
            if (collection == null) return NotFound();

            ViewBag.Authors = new SelectList(await _authorService.GetAllAuthorsAsync(), "PkAuthor", "Name_author", collection.FKAuthor);
            ViewBag.Topics = new SelectList(_topicService.ObtenerTopics(), "PkTopic", "Name_topic", collection.FKTopic);

            return View(collection);
        }

        [HttpPost]
        [CustomAuthorize(Roles = "Admin, User")]
        public async Task<IActionResult> Edit(int id, Collection collection)
        {
            if (id != collection.PkCollection) return NotFound();

                await _collectionService.UpdateCollectionAsync(collection);
                return RedirectToAction(nameof(Index));

            return View(collection);
        }

        [HttpPost]
        [CustomAuthorize(Roles = "Admin, User")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _collectionService.DeleteCollectionAsync(id);
                TempData["Message"] = "Colección eliminada correctamente.";
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Error al eliminar la colección: " + ex.Message;
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
