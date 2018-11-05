using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutiApp.MyModel
{
    public class UserLog : BaseModel
    {
        public Employee Employees { get; set; }
        public string Email { get; set; }
        public string Activity { get; set; }
    }
}
