using Domain_Layer.Interfaces;
using Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Infrastructure.Data.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(LibraryContext context) : base(context)
        {
        }

        public List<Book> GetAll()
        {
            return _dbSet.Include(b => b.Author).ToList();
        }

        public List<Book> GetBooksByGenre(string genre)
        {
            return _context.Books.Where(b => b.Genre == genre).ToList();
        }
    }
}
