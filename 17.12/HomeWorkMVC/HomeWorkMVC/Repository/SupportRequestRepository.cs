using System;
using System.Collections.Generic;
using HomeWorkMVC.Data;
using HomeWorkMVC.Interface;
using HomeWorkMVC.Models;
using System.Linq;
using HomeWorkMVC.DTO;
using Microsoft.EntityFrameworkCore;

namespace HomeWorkMVC.Repository
{
    public class SupportrequestRepository : ISupportRequestRepository
    {
        private readonly SupportDbContext _context;
        private readonly IRandomSpecialistService _randomSpecialist;

        public SupportrequestRepository(SupportDbContext context, IRandomSpecialistService randomSpecialist)
        {
            _context = context;
            _randomSpecialist = randomSpecialist;
        }

        public List<SupportRequestTable> GetAllRequests()
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
                }).ToList();
            return requests;
        }

        public SupportRequest GetDetails(string id)
        {
            var request = _context.SupportRequests
                .Include(sr => sr.Department)
                .Include(sr => sr.SupportSpecialist)
                .Include(sr => sr.Status)
                .FirstOrDefault(sr => sr.Id == Guid.Parse(id));
            return request;
        }

        public void ChangeStatus(string requestId, SupportRequestStatus status)
        {
            var request = _context.SupportRequests.FirstOrDefault(sr => sr.Id == Guid.Parse(requestId));
            request.Status = status;
            _context.Update(request);
            _context.SaveChanges();
        }

        public void CreateRequest(SupportRequestCreate newRequest)
        {
            var request = new SupportRequest()
            {
                Topic = newRequest.Topic,
                Description = newRequest.Description,
                Status = newRequest.RequestStatus,
                DepartmentId = Guid.Parse(newRequest.DepartmentId),
                SupportSpecialist = _randomSpecialist.SelectSpecialist()
            };
            _context.Add(request);
            _context.SaveChanges();
        }
    }
}