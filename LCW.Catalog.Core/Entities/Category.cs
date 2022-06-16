using System;
using System.Collections.Generic;
using System.Text;

namespace LCW.Catalog.Core.Entities
{
    public class Category:BaseEntity
    {
        public ICollection<Product> Products { get; set; }

    }
}
