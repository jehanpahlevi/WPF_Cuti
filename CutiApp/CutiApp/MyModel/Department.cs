using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutiApp.MyModel
{
    public class Department : BaseModel
    {
        public Company Companies { get; set; }
        string Name { get; set; }
        string ManagerId { get; set; }
    }
}
