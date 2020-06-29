using System;
using HR.Api.Models;

namespace HR.Api.ViewModels
{
    public class EmployeeViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public EmploymentType EmploymentType { get; set; }
    }
}