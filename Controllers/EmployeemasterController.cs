using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Employee.API.Model;
using Microsoft.AspNetCore.Cors;

namespace Employee.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class EmployeemasterController : ControllerBase
    {
        private readonly EmployeeDbContext _context;

        public EmployeemasterController(EmployeeDbContext context)
        {
            _context = context;
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
            var employeeData = await _context.EmployeeData.FindAsync(id);

            if (employeeData == null)
            {
                return NotFound();
            }

            return employeeData;
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
        public async Task<ActionResult<EmployeeData>> PostEmployeeData(EmployeeData employeeData)
        {
            _context.EmployeeData.Add(employeeData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeData", new { id = employeeData.employeeId }, employeeData);
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
