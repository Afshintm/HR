using System;
using System.Collections.Generic;
using System.Linq;
using HR.Api.Models;

namespace HR.Api.Infrastructure
{
    public interface IDocumentStore
    {
    }

    public class DocumentStore: IDocumentStore
    {
        public List<Person> Persons { get; set; }
        public List<Employee> Employees { get; set; }

        public DocumentStore()
        {
            Persons = new List<Person>
            {
                Person.CreateNew("Afshin","Teymoori",Gender.Male,new DateTime(1973,11,23)),
                Person.CreateNew("Kayvan","Teymoori",Gender.Male,new DateTime(1975,2,22)),
                Person.CreateNew("Iman","Teymoori",Gender.Male,new DateTime(1984,4,28)),
            };
            
            Employees = new List<Employee>
            {
                new Employee
                {
                    EmploymentType = EmploymentType.FullTime,
                    Person = Persons.FirstOrDefault(x=>x.FirstName =="Afshin"),
                    StartDate = new DateTime(2020,8,1)
                }
            };
        }
    }
}