using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Category.Models
{
    public class Employee
    {
        public int E_id { get; set; }
        public string E_name { get; set; }
        public int E_salary { get; set; }

        public int D_id { get; set; }
    }
    public class Department
    {
        public int D_id { get; set; }
        public string D_name { get; set; }
    }
}
