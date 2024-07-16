using System.Collections.Generic;
using Service_Layer.DTO;

namespace Service_Layer.Interfaces
{
    public interface IBookService
    {
        List<BookDTO> GetAllBooks();
        BookDTO GetBookById(int id);
        void AddBook(BookDTO book);
        void UpdateBook(BookDTO book);
        void DeleteBook(int id);
    }
}
