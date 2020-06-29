using System;
using System.Collections.Generic;
using HR.Api.Core;
using HR.Api.DomainEvents;
using HR.Api.Services;

namespace HR.Api.Models
{
    public class Company: AggregateRoot
    {
        private string _name;
        public List<Employee> Employees { get; private set; }

        public Company(string name)
        {
            _name = name;
            Employees = new List<Employee>();
        }

        public void Hire(Person person, EmploymentType employmentType)
        {
            var employee = new Employee {Person = person, EmploymentType = employmentType, StartDate = DateTime.UtcNow};
            var employmentContract = EmploymentContract.CreateNew(employee,this,employmentType);
            Emit(new EmploymentStarted(this,employee,default));
        }

    }
}