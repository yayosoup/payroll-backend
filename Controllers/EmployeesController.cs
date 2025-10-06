using Microsoft.AspNetCore.Mvc;
using payroll_backend.Data;
using payroll_backend.Models;


namespace payroll_backend.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : Controller {
        private readonly PayrollContext _context;

        public EmployeesController(PayrollContext context) { _context = context; }

        // GET: api/Employees
        [HttpGet]
        public IActionResult GetAll() {
            var employees = _context.Employees.ToList();
            return Ok(employees);
        }
        // GET: api/Employees/5
        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            var employee = _context.Employees.Find(id);
            if (employee == null) return NotFound();
            return Ok(employee);
        }

        // POST: api/Employees
        [HttpPost]
        public IActionResult Add(Employee employee) {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = employee.employeeID }, employee);
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, Employee updated) {
            var employee = _context.Employees.Find(id);
            if (employee == null) return NotFound();

            employee.employeeID = updated.employeeID;
            employee.hourlyWage = updated.hourlyWage;

            _context.SaveChanges();
            return Ok(employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            var employee = _context.Employees.Find(id);
            if (employee == null) return NotFound();

            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
