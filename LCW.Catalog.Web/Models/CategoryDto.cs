using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LCW.Catalog.Web.Models
{
    public class CategoryDto
    {
        [JsonConstructor]
        public CategoryDto()
        {

        }
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
