using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HomeWorkMVC.Data;
using HomeWorkMVC.Models;

namespace HomeWorkMVC.Service
{
    public class GetAllSelect
    {
        private readonly SupportDbContext _context;

        public GetAllSelect(SupportDbContext context)
        {
            _context = context;
        }

        public ICollection<SupportRequestStatus> AllStatuses()
        {
            return _context.SupportRequestStatuses.OrderBy(srs => srs.Id).ToList();
        }

        public ICollection<Department> AllDeparments()
        {
            return _context.Departments.OrderBy(d => d.Name).ToList();
        }
    }
}