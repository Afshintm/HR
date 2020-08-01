using System;
using System.Threading.Tasks;
using HR.Api.Commands;
using HR.Api.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HR.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private IMediator _mediator;
        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetEmployee(Guid id)
        {
            var query = new GetEmployeeDetailsQuery{Id = id};
            var response = await _mediator.Send(query);
            //use a mapper or ToViewModel which converts Response to viewModel 
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee()
        {
            var command = new CreateEmployeeCommand();
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}