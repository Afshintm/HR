using System;
using HR.Api.ViewModels;
using MediatR;

namespace HR.Api.Queries
{
    public class GetEmployeeDetailsQuery: IRequest<EmployeeViewModel>
    {
        public Guid Id { get; set; }

    }
}