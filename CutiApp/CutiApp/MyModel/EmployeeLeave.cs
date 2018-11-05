using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutiApp.MyModel
{
    public class EmployeeLeave : BaseModel
    {
        public Employee Employees { get; set; }
        public Leave Leaves { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public int TotalDays { get; set; }
        public string Backup { get; set; }
        public string Note { get; set; }
        public string Status { get; set; } 
    }
}
