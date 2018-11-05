using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutiApp.MyModel
{
    public class Employee : BaseModel
    { 
        public Department Departments { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telp { get; set; }
        public string JobTitle { get; set; }
        public string Status { get; set; }
        public int TotalChilds { get; set; }
        public string Password { get; set; }
        public int ThisYearBalance { get; set; }
        public int LastYearBalance { get; set; }
        public string Level { get; set; }
    }
}
