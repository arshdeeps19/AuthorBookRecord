using Domain_Layer.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;

namespace Infrastructure.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() : base("DefaultConnection")
        {
        }

        public DbSet<Author> Authors { get; set; } = null!;
        public DbSet<Book> Books { get; set; } = null!;
    }
}
