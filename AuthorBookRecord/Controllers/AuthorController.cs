using AuthorBookRecord.ViewModels;
using AutoMapper;
//using AuthorBookRecord.Application.ViewModels;
using Service_Layer.DTO;
using Service_Layer.Interfaces;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AuthorBookRecord.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public AuthorController(IAuthorService authorService, IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var authorDtos = _authorService.GetAllAuthors();
            var authorViewModels = _mapper.Map<List<ViewModels.AuthorViewModel>>(authorDtos);
            return View(authorViewModels);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AuthorViewModel authorViewModel)
        {
            if (ModelState.IsValid)
            {
                var authorDto = _mapper.Map<AuthorDTO>(authorViewModel);
                _authorService.AddAuthor(authorDto);
                return RedirectToAction("Index");
            }
            return View(authorViewModel);
        }

        public ActionResult Edit(int id)
        {
            var authorDto = _authorService.GetAuthorById(id);
            if (authorDto == null)
            {
                return HttpNotFound();
            }
            var authorViewModel = _mapper.Map<AuthorViewModel>(authorDto);
            return View(authorViewModel);
        }

        [HttpPost]
        public ActionResult Edit(AuthorViewModel authorViewModel)
        {
            if (ModelState.IsValid)
            {
                var authorDto = _mapper.Map<AuthorDTO>(authorViewModel);
                _authorService.UpdateAuthor(authorDto);
                return RedirectToAction("Index");
            }
            return View(authorViewModel);
        }

        public ActionResult Delete(int id)
        {
            var authorDto = _authorService.GetAuthorById(id);
            if (authorDto == null)
            {
                return HttpNotFound();
            }
            var authorViewModel = _mapper.Map<AuthorViewModel>(authorDto);
            return View(authorViewModel);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _authorService.DeleteAuthor(id);
            return RedirectToAction("Index");
        }
    }
}

