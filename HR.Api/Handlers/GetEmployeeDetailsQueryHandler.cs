using System.Threading;
using System.Threading.Tasks;
using HR.Api.Core;
using HR.Api.Extensions;
using HR.Api.Infrastructure;
using HR.Api.Models;
using HR.Api.Queries;
using HR.Api.ViewModels;

namespace HR.Api.Handlers
{
    public class GetEmployeeDetailsQueryHandler : RequestHandler<GetEmployeeDetailsQuery, EmployeeViewModel>
    {
        private IEntityRepository<Employee> _employeeRepository;
        public GetEmployeeDetailsQueryHandler(IEntityRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        protected override async Task<EmployeeViewModel> Execute(GetEmployeeDetailsQuery request, CancellationToken cancellationToken)
        {
             var employee = await _employeeRepository.FindByIdAsync(request.Id);
             return employee.ToViewModel();

        }
    }
}