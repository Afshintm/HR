using System.Threading;
using HR.Api.Models;

namespace HR.Api.DomainEvents
{
    public class EmploymentStarted: DomainEvent
    {
        private readonly Employee _employee;
        private readonly Company _company;

        public EmploymentStarted(Company company, Employee employee, CancellationToken cancellationToken)
        {
            _employee = employee;
            _company = company;
        }
    }
}