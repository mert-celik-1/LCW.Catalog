using LCW.Catalog.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCW.Catalog.Core.Dtos.ProductDtos
{
    public class ProductAddDto
    {

        public string Name { get; set; }

        public string Description { get; set; }

        public string CategoryId { get; set; }


        public Color Color { get; set; }


        public Status Status { get; set; }


        public Brand Brand { get; set; }

        public decimal Price { get; set; }
        public bool IsOfferable { get; set; }
    }
}
