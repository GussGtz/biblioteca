using Microsoft.AspNetCore.Mvc;
using BibliotecaSánchezLobatoGael83.Models.Domain;
using BibliotecaSánchezLobatoGael83.Services.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BibliotecaSánchezLobatoGael83.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [CustomAuthorize(Roles = "Admin, User")]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Author> authors = await _authorService.GetAllAuthorsAsync();
            return View(authors);
        }

        [CustomAuthorize(Roles = "Admin, User")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [CustomAuthorize(Roles = "Admin, User")]
        public async Task<IActionResult> Create(Author author)
        {
                await _authorService.AddAuthorAsync(author);
                return RedirectToAction(nameof(Index));
            return View(author);
        }

        [CustomAuthorize(Roles = "Admin, User")]
        public async Task<IActionResult> Edit(int id)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        [HttpPost]
        [CustomAuthorize(Roles = "Admin, User")]
        public async Task<IActionResult> Edit(Author author)
        {
                await _authorService.UpdateAuthorAsync(author);
                return RedirectToAction(nameof(Index));
            return View(author);
        }

        [HttpPost]
        [CustomAuthorize(Roles = "Admin, User")]
        public async Task<IActionResult> Delete(int id)
        {
            await _authorService.DeleteAuthorAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
