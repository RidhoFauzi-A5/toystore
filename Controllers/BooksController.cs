using Microsoft.AspNetCore.Mvc;
using GrandLineBooks.Models;
using GrandLineBooks.Services;
using MongoDB.Driver;

namespace GrandLineBooks.Controllers
{
    public class BooksController : Controller
    {
        private readonly MongoDBService _mongoDBService;

        public BooksController(MongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }

        // GET: Books (List all books)
        public async Task<IActionResult> Index()
        {
            var books = await _mongoDBService.Books.Find(_ => true).ToListAsync();
            return View(books);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            book.CreatedAt = DateTime.Now;
            await _mongoDBService.Books.InsertOneAsync(book);
            return RedirectToAction("Index");
        }

        // GET: Books/Edit/id
        public async Task<IActionResult> Edit(string id)
        {
            var book = await _mongoDBService.Books
                .Find(b => b.Id == id)
                .FirstOrDefaultAsync();
            return View(book);
        }

        // POST: Books/Edit/id
        [HttpPost]
        public async Task<IActionResult> Edit(string id, Book book)
        {
            var filter = Builders<Book>.Filter.Eq(b => b.Id, id);
            await _mongoDBService.Books.ReplaceOneAsync(filter, book);
            return RedirectToAction("Index");
        }

        // GET: Books/Delete/id
        public async Task<IActionResult> Delete(string id)
        {
            var filter = Builders<Book>.Filter.Eq(b => b.Id, id);
            await _mongoDBService.Books.DeleteOneAsync(filter);
            return RedirectToAction("Index");
        }

        // GET: Books/Details/id
        public async Task<IActionResult> Details(string id)
        {
            var book = await _mongoDBService.Books
                .Find(b => b.Id == id)
                .FirstOrDefaultAsync();
            return View(book);
        }
    }
}