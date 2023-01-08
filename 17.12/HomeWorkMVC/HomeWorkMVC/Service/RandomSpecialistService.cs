using System.Linq;
using HomeWorkMVC.Data;
using HomeWorkMVC.Interface;
using HomeWorkMVC.Models;

namespace HomeWorkMVC.Service
{
    public class RandomSpecialistService : IRandomSpecialistService
    {
        private readonly SupportDbContext _context;

        public RandomSpecialistService(SupportDbContext context)
        {
            _context = context;
        }

        public SupportSpecialist SelectSpecialist()
        {
            var specialist = _context.SupportSpecialists.OrderBy(ss => ss.SupportRequests.Count).ToList();
            return specialist[0];
        }
    }
}