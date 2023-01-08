using System;
using System.Linq;
using HomeWorkMVC.Data;
using HomeWorkMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeWorkMVC.Controllers
{
    public class TableController : Controller
    {
        private readonly SupportDbContext _context;

        public TableController(SupportDbContext context)
        {
            _context = context;
        }

        public IActionResult GetAllSupportRequest()
        {
            var requests = (from sr in _context.SupportRequests
                join ss in _context.SupportSpecialists on sr.SupportSpecialistId equals ss.Id
                join d in _context.Departments on ss.DepartmentId equals d.Id
                select new SupportRequestTable()
                {
                    Id = sr.Id,
                    Topic = sr.Topic,
                    DepartmentName = d.Name,
                    SpecialistName = ss.FullName,
                    Status = sr.Status.StatusName
                }).ToArray();

            return View(requests);
        }
        
        public IActionResult GetDetails(string id)
        {
            var request = _context.SupportRequests
                .Include(sr => sr.Department)
                .Include(sr => sr.SupportSpecialist)
                .FirstOrDefault(sr => sr.Id == Guid.Parse(id));
            return View(request);
        }

        [HttpPost]
        public IActionResult UpdateStatus([FromForm]string requestId, SupportRequestStatus status)
        {
            var request = _context.SupportRequests.FirstOrDefault(sr => sr.Id == Guid.Parse(requestId));
            request.Status = status;
            _context.Update(request);
            _context.SaveChanges();
            return NoContent();
        }

        public IActionResult NewRequest()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult NewRequest([FromForm]SupportRequest supportRequest)
        {
            
            return View("~/Views/Table/NewRequest.cshtml");
        }
    }
}