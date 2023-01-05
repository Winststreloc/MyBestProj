using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeWork09._12.Data;
using HomeWork09._12.Interfaces;
using HomeWork09._12.Models;
using HomeWork09._12.Services;
using Microsoft.EntityFrameworkCore;

namespace HomeWork09._12.Repository
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly LibraryDbContext _context;
        private readonly ILibraryGenerate _generate;

        public LibraryRepository(LibraryDbContext context, ILibraryGenerate generate)
        {
            _context = context;
            _generate = generate;
        }

        public async Task CreateModelsData()
        {
            await _generate.GenerateLibrary();
        }

        public async Task<IEnumerable<TakenBook>> GetTakenBooks()
        {
            var takenBook = (from ub in _context.UserBooks
                join u in _context.Users on ub.BookId equals u.UserId
                join b in _context.Books on ub.UserId equals b.BookId
                join au in _context.Authors on b.AuthorId equals au.AuthorId
                select new TakenBook
                {
                    UserFullName = u.FirstName + " " + u.LastName,
                    UserBirthDate = u.BirthDate,
                    BookName = b.Name,
                    BookYear = b.Year,
                    AuthorFullName = au.FirstName + " " + au.LastName,
                }).ToListAsync();

            return await takenBook;
        }

        public async Task<IEnumerable<string>> DeleteInActiveUsers()
        {
            var usersToDelete = _context.Users.Where(u => u.UserBooks
                .Select(ub => ub.User)
                .All(x => x != u)).ToArrayAsync();

            _context.Users.RemoveRange(await usersToDelete);
            await _context.SaveChangesAsync();

            var names = new List<string>();

            foreach (var user in await usersToDelete)
            {
                names.Add(user.FirstName + user.LastName);
            }

            return names;
        }

        public async Task ReturnBook(string userEmail, string nameBook)
        {
            var book = _context.UserBooks.FirstOrDefaultAsync(u => u.User.Email == userEmail
                                                                   && u.Book.Name == nameBook);

            _context.Remove(book);
            _context.SaveChangesAsync();
        }
    }
}