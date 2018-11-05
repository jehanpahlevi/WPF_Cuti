using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutiApp.MyModel
{
    public class Karyawan : BaseModel
    { 
        public string Nama { get; set; }
        public string Email { get; set; }
        public string NoTelp { get; set; }
        public string JobTitle { get; set; }
        public string Status { get; set; }
        public int JumlahAnak { get; set; }
        public string Password { get; set; }
        public int ThisYearBalance { get; set; }
        public int LastYearBalance { get; set; }
    }
}
