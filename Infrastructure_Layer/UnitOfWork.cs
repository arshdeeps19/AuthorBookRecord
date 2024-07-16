using Domain_Layer.Interfaces;
using Infrastructure.Data.Repositories;
using System;

namespace Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryContext _context;
        private readonly IAuthorRepository AuthorRepository;
        private readonly IBookRepository BookRepository;

        public UnitOfWork(LibraryContext context)
        {
            _context = context;
            AuthorRepository = new AuthorRepository(_context);
            BookRepository = new BookRepository(_context);
        }

        IAuthorRepository IUnitOfWork.Authors => this.AuthorRepository;

        IBookRepository IUnitOfWork.Books => this.BookRepository;

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

