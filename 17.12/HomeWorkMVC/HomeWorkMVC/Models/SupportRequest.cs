using System;

namespace HomeWorkMVC.Models
{
    public class SupportRequest
    {
        public Guid Id { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        public string SupportRequestStatus { get; set; }
        public Guid SupportSpecialistId { get; set; }
        public SupportSpecialist SupportSpecialist { get; set; }
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}