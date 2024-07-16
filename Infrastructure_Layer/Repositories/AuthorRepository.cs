using Domain_Layer.Interfaces;
using System.Data.Entity;
using Domain_Layer.Models;
using System;
using System.Linq;

namespace Infrastructure.Data.Repositories
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(LibraryContext context) : base(context)
        {
        }

        public Author GetAuthorWithBooks(int authorId)
        {
            return _context.Authors.Include(a => a.Books)
                                   .FirstOrDefault(a => a.AuthorId == authorId) ?? new Author();
        }
    }
}

