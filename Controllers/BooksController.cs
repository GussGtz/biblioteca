using BibliotecaSánchezLobatoGael83.Models.Domain;
using BibliotecaSánchezLobatoGael83.Services;
using BibliotecaSánchezLobatoGael83.Services.Interfaces;
using BibliotecaSánchezLobatoGael83.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BibliotecaSánchezLobatoGael83.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly ITopicServices _topicService;
        private readonly ICollectionService _collectionService;
        private readonly IUsuarioBookService _usuarioBookService;

        public BooksController(IBookService bookService, IAuthorService authorService, ITopicServices topicService, ICollectionService collectionService, IUsuarioBookService usuarioBookService)
        {
            _bookService = bookService;
            _authorService = authorService;
            _topicService = topicService;
            _collectionService = collectionService;
            _usuarioBookService = usuarioBookService;
        }

        [CustomAuthorize(Roles = "Admin")]
        public async Task<IActionResult> Dashboard()
        {
            var bookCount = await _bookService.CountBooksAsync();
            var authorCount = await _authorService.CountAuthorsAsync();
            var topicCount = await _topicService.CountTopicsAsync();
            var collectionCount = await _collectionService.CountCollectionsAsync();
            var userBookCount = await _usuarioBookService.CountUsuarioBooksAsync();

            var dashboardData = new
            {
                Books = bookCount,
                Authors = authorCount,
                Topics = topicCount,
                Collections = collectionCount,
                UsuarioBooks = userBookCount
            };

            return View(dashboardData);
        }

        [CustomAuthorize(Roles = "Admin, User")]
        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetAllBooksAsync() ?? new List<Book>(); // Si es null, retorna una lista vacía
            return View(books);
        }

        [CustomAuthorize(Roles = "Admin, User, Guest")]
        public async Task<IActionResult> IndexBook()
        {
            var books = await _bookService.GetAllBooksAsync() ?? new List<Book>();
            return View(books);
        }

        [CustomAuthorize(Roles = "Admin, User, Guest")]
        public async Task<IActionResult> Details(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null) return NotFound();

            return View(book);
        }

        [CustomAuthorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            ViewBag.Authors = new SelectList(await _authorService.GetAllAuthorsAsync(), "PkAuthor", "Name_author");
            ViewBag.Topics = new SelectList(_topicService.ObtenerTopics(), "PkTopic", "Name_topic");
            ViewBag.Collections = new SelectList(await _collectionService.GetAllCollectionsAsync(), "PkCollection", "Name_collection");
            return View();
        }

        [HttpPost]
        [CustomAuthorize(Roles = "Admin")]
        public async Task<IActionResult> Create(Book book)
        {
                await _bookService.AddBookAsync(book);
                return RedirectToAction(nameof(Index));

            ViewBag.Authors = new SelectList(await _authorService.GetAllAuthorsAsync(), "PkAuthor", "Name_author");
            ViewBag.Topics = new SelectList(_topicService.ObtenerTopics(), "PkTopic", "Name_topic");
            ViewBag.Collections = new SelectList(await _collectionService.GetAllCollectionsAsync(), "PkCollection", "Name_collection");
            return View(book);
        }

        [CustomAuthorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null) return NotFound();

            ViewBag.Authors = new SelectList(await _authorService.GetAllAuthorsAsync(), "PkAuthor", "Name_author", book.FKAuthors);
            ViewBag.Topics = new SelectList(_topicService.ObtenerTopics(), "PkTopic", "Name_topic", book.FKTopic);
            ViewBag.Collections = new SelectList(await _collectionService.GetAllCollectionsAsync(), "PkCollection", "Name_collection", book.FKCollection);

            return View(book);
        }

        [HttpPost]
        [CustomAuthorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, Book book)
        {
            if (id != book.PkBook) return NotFound();

                await _bookService.UpdateBookAsync(book);
                return RedirectToAction(nameof(Index));

            ViewBag.Authors = new SelectList(await _authorService.GetAllAuthorsAsync(), "PkAuthor", "Name_author", book.FKAuthors);
            ViewBag.Topics = new SelectList(_topicService.ObtenerTopics(), "PkTopic", "Name_topic", book.FKTopic);
            ViewBag.Collections = new SelectList(await _collectionService.GetAllCollectionsAsync(), "PkCollection", "Name_collection", book.FKCollection);
            return View(book);
        }

        [HttpPost]
        [CustomAuthorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _bookService.DeleteBookAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}