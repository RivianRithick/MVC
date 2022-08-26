using System;
using System.Collections.Generic;

namespace MVC.Model
{
    public partial class Product
    {
        public string Name { get; set; } = null!;
        public string Price { get; set; } = null!;
        public int Pid { get; set; }
        public int? Sid { get; set; }

        public virtual Supplier? SidNavigation { get; set; }
    }
}
