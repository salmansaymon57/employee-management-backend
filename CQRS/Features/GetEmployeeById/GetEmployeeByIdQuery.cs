using Employee.API.Model;
using MediatR;

namespace Employee.API.Features.Employees.GetEmployeeById
{
    public record GetEmployeeByIdQuery(int employeeId) : IRequest<EmployeeData?>
    {
    }
}
