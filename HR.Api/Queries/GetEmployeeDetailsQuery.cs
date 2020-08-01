using HR.Api.Domain.Seed;
using MediatR;

namespace HR.Api.Queries
{
    public class GetEmployeeDetailsQuery: BaseEntityRequest,IRequest<AggregateRoot>
    {
    }
}