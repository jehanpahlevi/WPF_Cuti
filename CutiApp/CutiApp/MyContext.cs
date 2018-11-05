using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CutiApp.MyModel;

namespace CutiApp
{
    public class MyContext : DbContext
    {
        public MyContext() : base("CutiApp") {}
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<EmployeeLeave> EmployeeLeaves { get; set; }
        public DbSet<UserLog> UserLogs { get; set; }
    }
}
