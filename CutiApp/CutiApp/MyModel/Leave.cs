using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutiApp.MyModel
{
    public class Leave : BaseModel
    {
        public string LeaveType { get; set; }
        public int LengthDays { get; set; }

    }
}
