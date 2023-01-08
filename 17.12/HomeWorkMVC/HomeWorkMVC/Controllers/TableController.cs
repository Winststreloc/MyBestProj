using System;
using System.Linq;
using HomeWorkMVC.Data;
using HomeWorkMVC.DTO;
using HomeWorkMVC.Interface;
using HomeWorkMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeWorkMVC.Controllers
{
    public class TableController : Controller
    {
        private readonly ISupportRequestRepository _repository;

        public TableController(ISupportRequestRepository repository)
        {
            _repository = repository;
        }

        public IActionResult GetAllSupportRequest()
        {
            var requests = _repository.GetAllRequests();
            return View(requests);
        }
        
        public IActionResult GetDetails(string id)
        {
            var request = _repository.GetDetails(id);
            return View(request);
        }

        [HttpPost]
        public IActionResult UpdateStatus([FromForm]string requestId, SupportRequestStatus status)
        {
            _repository.ChangeStatus(requestId, status);
            return NoContent();
        }

        public IActionResult NewRequest()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult NewRequest([FromForm]SupportRequestCreate supportRequest)
        {
            _repository.CreateRequest(supportRequest);
            return View("~/Views/Home/Index.cshtml");
        }
    }
}