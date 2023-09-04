using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Category.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public int Cid { get; set; }

    }

    public class Category
    {
        public int Cid { get; set; }
        public string Cname { get; set; }
    }
}
