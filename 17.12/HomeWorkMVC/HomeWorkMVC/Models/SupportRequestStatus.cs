using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace HomeWorkMVC.Models
{
    public class SupportRequestStatus
    {
        public int Id { get; set; }
        public string StatusName { get; set; }
        public ICollection<SupportRequest> SupportRequests { get; set; }
    }
}