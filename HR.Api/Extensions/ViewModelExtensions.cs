using HR.Api.Models;
using HR.Api.ViewModels;
using Microsoft.AspNetCore.Diagnostics;

namespace HR.Api.Extensions
{
    public static class ViewModelExtensions
    {
        public static EmployeeViewModel  ToViewModel(this Employee employee)
        {
            if (employee == null)
                return null;
            return new EmployeeViewModel
            {
                Id = employee.Id,
                EmploymentType = employee.EmploymentType,
                Name = employee.FullName
            };
        }
    }
}