using System;
using System.Collections.Generic;
using System.Drawing;

namespace HomeWorkMVC.Models
{
    public class Department
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<SupportRequest> SupportRequests { get; set; }
        public ICollection<SupportSpecialist> SupportSpecialists { get; set; }
    }
}