using System;
using System.Collections.Generic;
using HomeWorkMVC.DTO;
using HomeWorkMVC.Models;

namespace HomeWorkMVC.Interface
{
    public interface ISupportRequestRepository
    {
        List<SupportRequestTable> GetAllRequests();
        SupportRequest GetDetails(string id);
        void ChangeStatus(string id, SupportRequestStatus status);
        void CreateRequest(SupportRequestCreate request);
    }
}