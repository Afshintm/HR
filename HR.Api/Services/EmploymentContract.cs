using System;
using System.Threading;
using HR.Api.Core;
using HR.Api.Domain.Seed;
using HR.Api.DomainEvents;
using HR.Api.Models;

namespace HR.Api.Services
{
    public class EmploymentContract: AggregateRoot
    {
        public Employee Employee { get; private set; }
        public Company Company { get; private set; }
        public DateTime StartDate { get; private set; }
        public EmploymentType EmploymentType { get; private set; }
        public ContractStatus ContractStatus { get; private set; }

        public static EmploymentContract CreateNew(
            Employee employee, 
            Company company, 
            EmploymentType employmentType,
            DateTime startDate = default)
        {
            if( employee == null)
                throw new ApplicationException("employee cannot be null");
            
            return new EmploymentContract{ 
                Employee = employee, 
                Company = company, 
                StartDate = startDate==default ? DateTime.UtcNow : startDate,
                EmploymentType = employmentType,
                ContractStatus = ContractStatus.Initialized
            };
        }

        public void Sign()
        {
            ContractStatus = ContractStatus.Signed;
        }

        public void Start()
        {
            ContractStatus = ContractStatus.InProgress;
            StartDate = DateTime.UtcNow;
            Emit(new EmploymentStarted(Company, Employee,new CancellationToken()));
        }
    }
}