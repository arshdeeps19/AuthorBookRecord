﻿using Domain_Layer.Models;

namespace Service_Layer.DTO
{
    public class BookDTO
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string PublishDate { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}