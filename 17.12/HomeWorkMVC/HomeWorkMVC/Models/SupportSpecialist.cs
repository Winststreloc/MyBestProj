using System;
using System.Collections.Generic;

namespace HomeWorkMVC.Models
{
    public class SupportSpecialist
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<SupportRequest> SupportRequests { get; set; }
    }
}