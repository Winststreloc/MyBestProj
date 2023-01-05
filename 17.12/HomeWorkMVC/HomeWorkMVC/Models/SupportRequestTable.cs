using System;

namespace HomeWorkMVC.Models
{
    public class SupportRequestTable
    {
        public Guid Id { get; set; }
        public string Topic { get; set; }
        public string DepartmentName { get; set; }
        public string SpecialistName { get; set; }
        public string Status { get; set; }
    }
}