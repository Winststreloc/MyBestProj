using System.Collections.Generic;
using System.Threading.Tasks;
using HomeWork09._12.Data;
using HomeWork09._12.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork09._12
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : Controller
    {
        private readonly ILibraryRepository _repository;

        public LibraryController(ILibraryRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("generate-library-task7")]
        public async Task<IActionResult> GenerateLibrary()
        {
            await _repository.CreateModelsData();
            return Ok();
        }

        [HttpGet("get-taken-books-task8")]
        public async Task<IActionResult> GetTakenBook()
        {
            var takenBooks =  await _repository.GetTakenBooks();
            return Ok(takenBooks);
        }

        
        [HttpDelete("delete-inactive-user-task9")]
        public async Task<IEnumerable<string>> DeleteInactiveUsers()
        {
            var users = _repository.DeleteInActiveUsers();
            return await users;
        }

        [HttpPost("return-book")]
        public async Task<IActionResult> ReturnBook([FromQuery]string userEmail, [FromQuery]string bookName)
        {
            await _repository.ReturnBook(userEmail, bookName);
            return NoContent();
        }

        [HttpGet("return-book")]
        public IActionResult Get()
        {
            return Ok("ok");
        }
        
    }
}