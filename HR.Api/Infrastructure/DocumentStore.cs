using System.Collections.Generic;
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
                new Person(){""}
                
            };
            
            Employees = new List<Employee>
            {
                new Employee()
                {
                    EmploymentType = EmploymentType.FullTime;
                        
                }
            };
        }
    }
}