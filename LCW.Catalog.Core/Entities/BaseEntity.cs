using System;
using System.Collections.Generic;
using System.Text;

namespace LCW.Catalog.Core.Entities
{
    public class BaseEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
