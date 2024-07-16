using System;
using System.Collections.Generic;

namespace Domain_Layer.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public ICollection<Book> Books { get; set; }

        public Author()
        {
            Books = new List<Book>();                  // Initiazed the Books collection to avoid null reference issues
        }
    }
}
