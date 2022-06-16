using LCW.Catalog.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LCW.Catalog.Web.ViewModels
{
    public class HomeIndexViewModel
    {
        public List<CategoryDto> Categories { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}
