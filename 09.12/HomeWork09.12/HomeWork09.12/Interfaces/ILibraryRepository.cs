using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using HomeWork09._12.Models;

namespace HomeWork09._12.Interfaces
{
    public interface ILibraryRepository
    {
        Task CreateModelsData();
        Task<IEnumerable<TakenBook>> GetTakenBooks();
        Task<IEnumerable<string>> DeleteInActiveUsers();
        Task ReturnBook(string userEmail, string nameBook);
    }
}