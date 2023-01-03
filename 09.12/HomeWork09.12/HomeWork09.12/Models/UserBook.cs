using System;

namespace HomeWork09._12.Models
{
    public class UserBook
    {
        public Guid UserBookId { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }
    }
}