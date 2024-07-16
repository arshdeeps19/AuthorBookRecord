using System.Web.Mvc;
using Service_Layer.Interfaces;
using AuthorBookRecord.ViewModels;
using AutoMapper;
using Service_Layer.DTO;
using System.Collections.Generic;

namespace AuthorBookRecord.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public BookController(IBookService bookService, IAuthorService authorService, IMapper mapper)
        {
            _bookService = bookService;
            _authorService = authorService;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var dtos = _bookService.GetAllBooks();
            var books = _mapper.Map<List<ViewModels.BookViewModel>>(dtos);
            return View(books);
        }

        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(_authorService.GetAllAuthors(), "AuthorId", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(BookViewModel bookViewModel)
        {
            if (ModelState.IsValid)
            {
                var bookDto = _mapper.Map<BookDTO>(bookViewModel);
                _bookService.AddBook(bookDto);
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(_authorService.GetAllAuthors(), "AuthorId", "Name", bookViewModel.AuthorId);
            return View(bookViewModel);
        }

        public ActionResult Edit(int id)
        {
            var dto = _bookService.GetBookById(id);
            if (dto == null)
            {
                return HttpNotFound();
            }
            var vm = _mapper.Map<BookViewModel>(dto);
            ViewBag.AuthorId = new SelectList(_authorService.GetAllAuthors(), "AuthorId", "Name");
            return View(vm);
        }

        [HttpPost]
        public ActionResult Edit(BookViewModel bookViewModel)
        {
            if (ModelState.IsValid)
            {
                var dto = _mapper.Map<BookDTO>(bookViewModel);
                _bookService.UpdateBook(dto);
                return RedirectToAction("Index");
            }
            return View(bookViewModel);
        }

        public ActionResult Delete(int id)
        {
            var dto = _bookService.GetBookById(id);

            if (dto == null)
            {
                return HttpNotFound();
            }
            var vm = _mapper.Map<BookViewModel>(dto);
            return View(vm);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _bookService.DeleteBook(id);
            return RedirectToAction("Index");
        }
    }
}
