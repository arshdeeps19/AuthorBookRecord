using AutoMapper;
using Service_Layer.DTO;
using Domain_Layer.Interfaces;
using Domain_Layer.Models;
using Service_Layer.Interfaces;
using System.Collections.Generic;

namespace Service_Layer.Services
{
    public class BookService: IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<BookDTO> GetAllBooks()
        {
            var books = _unitOfWork.Books.GetAll();
            return _mapper.Map<List<BookDTO>>(books);
        }     

        public BookDTO GetBookById(int id)
        {
            var book = _unitOfWork.Books.GetById(id);
            return _mapper.Map<BookDTO>(book);
        }

        public void AddBook(BookDTO bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            _unitOfWork.Books.Insert(book);
            _unitOfWork.Save();
        }

        public void UpdateBook(BookDTO bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            _unitOfWork.Books.Update(book);
            _unitOfWork.Save();
        }

        public void DeleteBook(int id)
        {
            _unitOfWork.Books.Delete(id);
            _unitOfWork.Save();
        }
    }
}
