using System;

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

    public class Employee: Entity,IEmployed
    {
        public Person Person;
        public DateTime StartDate { get; set; }
        public EmploymentType EmploymentType { get; set; }
        public string FullName => Person.FirstName+" "+Person.LastName;
    }
}