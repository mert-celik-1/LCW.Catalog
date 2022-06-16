﻿using LCW.Catalog.Web.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LCW.Catalog.Web.Models
{
    public class ProductDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsOfferable { get; set; }
        public CategoryDto Category { get; set; }
        public Color Color { get; set; }
        public Status Status { get; set; }
        public Brand Brand { get; set; }
        public bool IsSold { get; set; }

        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsAlreadyOffered { get; set; }

    }
}
