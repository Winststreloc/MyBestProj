﻿using System.Linq;
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

        // public IActionResult Index()
        // {
        //     return View();
        // }

        public IActionResult GetAllSupportRequest()
        {
            var requests = (from sr in _context.SupportRequests
                join ss in _context.SupportSpecialists on sr.SupportSpecialistId equals ss.Id
                join d in _context.Departments on ss.DepartmentId equals d.Id
                select new SupportRequestTable()
                {
                    Topic = sr.Topic,
                    DepartmentName = d.Name,
                    SpecialistName = ss.FullName,
                    Status = sr.SupportRequestStatus
                }).ToArray();

            return View(requests);
        }
    }
}