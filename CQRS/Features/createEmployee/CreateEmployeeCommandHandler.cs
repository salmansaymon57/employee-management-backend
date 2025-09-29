using Employee.API.Model;
using MediatR;

namespace Employee.API.Features.Employees.createEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, EmployeeData>
    {
        private readonly EmployeeDbContext _context;

        public CreateEmployeeCommandHandler(EmployeeDbContext context)
        {
            _context = context;
        }

        public async Task<EmployeeData> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {

            var employeeData = new EmployeeData 
            { 
                firstName = request.firstName,
                lastName = request.lastName , 
                email = request.email, 
                contactNo = request.contactNo, 
                city = request.city, 
                address = request.address
            };
            _context.EmployeeData.Add(employeeData);
            await _context.SaveChangesAsync(cancellationToken);

            return employeeData;
        }

        
    }
}

