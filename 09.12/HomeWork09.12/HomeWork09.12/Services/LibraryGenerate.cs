using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HomeWork09._12.Data;
using HomeWork09._12.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace HomeWork09._12.Services
{
    public class LibraryGenerate : ILibraryGenerate
    {
        private readonly LibraryDbContext _context;

        public LibraryGenerate(LibraryDbContext context)
        {
            _context = context;
        }
        

        private async Task GenerateAuthors()
        {
            if (!_context.Authors.Any())
            {
                var authors = new List<Author>()
                {
                    new Author()
                    {
                        AuthorId = new Guid("d92899ae-d2c8-4dd5-89ca-98cede503f0f"),
                        FirstName = "Lev",
                        LastName = "Tolsoy",
                        Country = "Russia",
                        BirthDate = new DateTime(1828, 09, 09)
                    },
                    new Author()
                    {
                        AuthorId = new Guid("334c488f-d0a4-43f8-aa21-c613f4f0c233"),
                        FirstName = "Fyodor",
                        LastName = "Dostoevsky",
                        Country = "Russia",
                        BirthDate = new DateTime(1821, 11, 11)
                    },
                    new Author()
                    {
                        AuthorId = new Guid("09ea12f6-1b90-4e23-b6ec-6513271fb053"),
                        FirstName = "Vladimir",
                        LastName = "Maykovsky",
                        Country = "Russia",
                        BirthDate = new DateTime(1893, 07, 19)
                    }
                };
                _context.AddRange(authors);
            }

            await _context.SaveChangesAsync();
        }

        private async Task GenerateUserBook()
        {
            if (!_context.UserBooks.Any())
            {
                var userBooks = new List<UserBook>()
                {
                    new UserBook()
                    {
                        User = new User()
                        {
                            UserId = Guid.Parse("89e1c91b-ff9f-4291-9fda-f3c52a92607f"),
                            FirstName = "Leonid",
                            LastName = "Leonidovich",
                            BirthDate = new DateTime(1991, 11, 24),
                            Email = "leonid@gmail.com"
                        },
                        Book = new Book()
                        {
                            BookId = Guid.Parse("f8835abd-945c-4b6f-a54b-0b7e274c1aa3"),
                            AuthorId = Guid.Parse("d92899ae-d2c8-4dd5-89ca-98cede503f0f"),
                            Name = "Voina i mir",
                            Year = new DateTime(1867, 01, 01)
                        },
                        UserId = Guid.Parse("89e1c91b-ff9f-4291-9fda-f3c52a92607f"),
                        BookId = Guid.Parse("f8835abd-945c-4b6f-a54b-0b7e274c1aa3"),
                        UserBookId = new Guid()
                    },
                    new UserBook()
                    {
                        User = new User()
                        {
                            UserId = Guid.Parse("110ee689-9b8f-4501-851f-24e90d9f50af"),
                            FirstName = "Ales",
                            LastName = "Alesevich",
                            BirthDate = new DateTime(2002, 01, 14),
                            Email = "ales@gmail.com"
                        },
                        Book = new Book()
                        {
                            BookId = Guid.Parse("f58dc38a-4f55-408d-b1c3-84842fd0f5b2"),
                            AuthorId = Guid.Parse("334c488f-d0a4-43f8-aa21-c613f4f0c233"),
                            Name = "Bratya Karamazovy",
                            Year = new DateTime(1880, 02, 02)
                        },
                        UserId = Guid.Parse("110ee689-9b8f-4501-851f-24e90d9f50af"),
                        BookId = Guid.Parse("f58dc38a-4f55-408d-b1c3-84842fd0f5b2"),
                        UserBookId = new Guid()
                    },
                    new UserBook()
                    {
                        User = new User()
                        {
                            UserId = Guid.Parse("955e444f-485c-4664-8563-c76fff9bcaf7"),
                            FirstName = "Darya",
                            LastName = "Daryevna",
                            BirthDate = new DateTime(2002, 05, 11),
                            Email = "darya@gmail.com"
                        },
                        Book = new Book()
                        {
                            BookId = Guid.Parse("e4217262-e5f3-4488-87e7-4d9adf7b2f72"),
                            AuthorId = Guid.Parse("09ea12f6-1b90-4e23-b6ec-6513271fb053"),
                            Name = "Oblako v shatanah",
                            Year = new DateTime(1914, 05, 05)
                        },
                        UserId = Guid.Parse("955e444f-485c-4664-8563-c76fff9bcaf7"),
                        BookId = Guid.Parse("e4217262-e5f3-4488-87e7-4d9adf7b2f72"),
                        UserBookId = new Guid()
                    }
                };
                _context.AddRange(userBooks);
            }

            await _context.SaveChangesAsync();
        }

        public async Task GenerateLibrary()
        {
            await GenerateAuthors();
            await GenerateUserBook();
        }
    }
}