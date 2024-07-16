using System.Collections.Generic;

namespace Domain_Layer.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; } 
        public string Genre { get; set; }
        public string PublishDate { get; set; }
        public int AuthorId { get; set; }  
        public virtual Author Author { get; set; }

        public Book()
        {
            Title = string.Empty;
            Genre = string.Empty;
        }
    }
}
