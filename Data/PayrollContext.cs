using Microsoft.EntityFrameworkCore;
using payroll_backend.Models;

namespace payroll_backend.Data {
    public class PayrollContext : DbContext
    {
        public PayrollContext(DbContextOptions<PayrollContext> options)
            :base(options) { }

        public DbSet<Employee> Employees => Set<Employee>();
    }
}
