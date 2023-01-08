using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HomeWorkMVC.Data;
using HomeWorkMVC.Models;

namespace HomeWorkMVC.Service
{
    public class GetAllStatuses
    {
        private readonly SupportDbContext _context;

        public GetAllStatuses(SupportDbContext context)
        {
            _context = context;
        }

        public ICollection<string> AllStatuses()
        {
            return _context.SupportRequestStatuses.Select(srs => srs.StatusName).ToList();
        }
        
    }
}