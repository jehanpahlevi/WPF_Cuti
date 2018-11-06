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
        public string Name { get; set; }
        public int ManagerId { get; set; }
    }
}
