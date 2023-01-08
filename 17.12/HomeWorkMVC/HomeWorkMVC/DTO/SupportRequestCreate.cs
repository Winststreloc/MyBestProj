using HomeWorkMVC.Models;

namespace HomeWorkMVC.DTO
{
    public class SupportRequestCreate
    {
        public string Topic { get; set; }
        public string Description { get; set; }
        public SupportRequestStatus RequestStatus { get; set; }
        public string DepartmentId { get; set; }
    }
}