using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Employee.API.Model;
using Microsoft.AspNetCore.Cors;
using MediatR;
using Employee.API.Features.Employees.createEmployee;
using Employee.API.Features.Employees.GetEmployeeById;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Employee.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class EmployeemasterController : ControllerBase
    {
        private readonly EmployeeDbContext _context;
        private readonly ISender _sender;

        public EmployeemasterController(EmployeeDbContext context, ISender sender   )
        {
            _context = context;
            _sender = sender;
        }

        // GET: api/Employeemaster
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeData>>> GetEmployeeData()
        {
            return await _context.EmployeeData.ToListAsync();
        }

        // GET: api/Employeemaster/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeData>> GetEmployeeData(int id)
        {

            var employee = await _sender.Send(new GetEmployeeByIdQuery(id));

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // PUT: api/Employeemaster/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeData(int id, EmployeeData employeeData)
        {
            if (id != employeeData.employeeId)
            {
                return BadRequest();
            }

            _context.Entry(employeeData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeDataExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Employeemaster
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeData>> PostEmployeeData(CreateEmployeeCommand command)
        {
            var employeeId = await _sender.Send(command);


            return Ok(employeeId);

        }

        // DELETE: api/Employeemaster/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeData(int id)
        {
            var employeeData = await _context.EmployeeData.FindAsync(id);
            if (employeeData == null)
            {
                return NotFound();
            }

            _context.EmployeeData.Remove(employeeData);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeDataExists(int id)
        {
            return _context.EmployeeData.Any(e => e.employeeId == id);
        }
    }
}
