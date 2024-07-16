using Domain_Layer.Models;
using System.Collections.Generic;

namespace Domain_Layer.Interfaces
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        List<Book> GetBooksByGenre(string genre);
    }
}
