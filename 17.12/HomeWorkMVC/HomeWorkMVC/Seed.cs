using System;
using System.Collections.Generic;
using HomeWorkMVC.Data;
using HomeWorkMVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore.Internal;

namespace HomeWorkMVC
{
    public class Seed
    {
        public static void SeedDataContext(SupportDbContext context)
        {
            if (!context.SupportSpecialists.Any())
            {
                var supportSpecialists = new List<SupportSpecialist>
                {
                    new SupportSpecialist()
                    {
                        Id = new Guid("65dce33b-2f79-450b-ba2f-ec5b83b9dbd3"),
                        FullName = "Michael Jordan",
                        Department = new Department()
                        {
                            Id = new Guid("3e9960fa-1fea-43b8-91d0-e45d2a20721c"),
                            Name = "Chicago Bulls"
                        }
                    },
                    new SupportSpecialist()
                    {
                        Id = new Guid("4246f8c4-dfb2-402b-bdc3-3c6dc03d79cf"),
                        FullName = "Stephen Curry",
                        Department = new Department()
                        {
                            Id = new Guid("772a8f0e-c3dd-43a1-b29d-1c8f13a43bed"),
                            Name = "Golden State Warriors"
                        }
                    },
                    new SupportSpecialist()
                    {
                        Id = new Guid("402d4544-dc07-480a-a725-f3368b929ffc"),
                        FullName = "Kevin Durant",
                        Department = new Department()
                        {
                            Id = new Guid("aa6da2bd-b504-48fd-b3de-5427e84d7fe1"),
                            Name = "Brooklyn Nets"
                        }
                    },
                    new SupportSpecialist()
                    {
                        Id = new Guid("0748183f-ed1d-484b-a38f-067bc88514ad"),
                        FullName = "Kyrie Irving",
                        DepartmentId = Guid.Parse("aa6da2bd-b504-48fd-b3de-5427e84d7fe1")
                    }
                };
                
                context.AddRange(supportSpecialists);
                context.SaveChanges();
            }

            if (!context.SupportRequests.Any())
            {
                var supportRequests = new List<SupportRequest>()
                {
                    new SupportRequest()
                    {
                        Id = new Guid("7e215efc-1c83-4e3d-9bec-f70f0483a4f2"),
                        Topic = "Studing in Course",
                        Description = "offline studying in courses is bette than online studying",
                        SupportRequestStatus = "Open",
                        SupportSpecialistId = Guid.Parse("4246f8c4-dfb2-402b-bdc3-3c6dc03d79cf"),
                        DepartmentId = Guid.Parse("772a8f0e-c3dd-43a1-b29d-1c8f13a43bed")
                    },
                    new SupportRequest()
                    {
                        Id = new Guid("cb36dc9d-0322-44f3-b25c-8b3576c904ea"),
                        Topic = "Kawhi Leonard in Clippers",
                        Description = "When Kawhi Leonard back in Clippers",
                        SupportRequestStatus = "Open",
                        SupportSpecialistId = Guid.Parse("0748183F-ED1D-484B-A38F-067BC88514AD"),
                        DepartmentId = Guid.Parse("AA6DA2BD-B504-48FD-B3DE-5427E84D7FE1")
                    },
                    
                };
                context.AddRange(supportRequests);
                context.SaveChanges();
            }
            
        }
    }
}