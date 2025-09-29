using Employee.API.Model;
using MediatR;

namespace Employee.API.Features.Employees.createEmployee
{
    public record CreateEmployeeCommand(string firstName,
                                        string lastName,
                                        string email,
                                        string contactNo,
                                        string city,
                                        string address) : IRequest<EmployeeData>
    {

    }
}
