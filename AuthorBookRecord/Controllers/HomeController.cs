using AutoMapper;
using Service_Layer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using AuthorBookRecord.ViewModels;

namespace AuthorBookRecord.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public HomeController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var dtos = _bookService.GetAllBooks();
            var books = _mapper.Map<List<BookViewModel>>(dtos);
            return View(books);
        }
    }
}