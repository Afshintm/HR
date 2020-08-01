using System;
using HR.Api.Domain.Seed;

namespace HR.Api.Models
{
    public interface IEmployed
    { 
        DateTime StartDate { get; set; }
        EmploymentType EmploymentType { get; set; }
    }

    public interface IContractor
    {
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
    }

    public class Employee: AggregateRoot,IEmployed
    {
        public Person Person;
        public DateTime StartDate { get; set; }
        public EmploymentType EmploymentType { get; set; }
        public string FullName => Person.FirstName+" "+Person.LastName;
    }
}