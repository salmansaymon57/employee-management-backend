using Employee.API.Model;
using MediatR;

namespace Employee.API.Features.Employees.GetEmployeeById
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeData?>

    {
        private readonly EmployeeDbContext _context;

        public GetEmployeeByIdQueryHandler(EmployeeDbContext context)
        {
            _context = context;
        }

        public async Task<EmployeeData?> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employeeData = await _context.EmployeeData.FindAsync(request.employeeId);

           

            return employeeData;

        }
    }
}
