using System;
using Domain_Layer.Interfaces;

namespace Domain_Layer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthorRepository Authors { get; }
        IBookRepository Books { get; }
        int Save();
    }
}
