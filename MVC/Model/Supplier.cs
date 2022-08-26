using System;
using System.Collections.Generic;

namespace MVC.Model
{
    public partial class Supplier
    {
        public Supplier()
        {
            Products = new HashSet<Product>();
        }

        public string Name { get; set; } = null!;
        public string City { get; set; } = null!;
        public int Sid { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
