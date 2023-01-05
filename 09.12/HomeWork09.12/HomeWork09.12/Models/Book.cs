using System;
using System.Collections.Generic;

namespace HomeWork09._12.Models
{
    public class Book
    {
        public Guid BookId { get; set; }
        public string Name { get; set; }
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
        public DateTime Year { get; set; }
        public ICollection<UserBook> UserBooks { get; set; }
    }
}