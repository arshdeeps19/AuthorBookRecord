using Domain_Layer.Models;
using System.Data.Entity;

namespace Infrastructure.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() : base("DefaultConnection")
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
