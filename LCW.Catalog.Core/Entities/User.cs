using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LCW.Catalog.Core.Entities
{
    public class User : IdentityUser<string>
    {
        public ICollection<Product> Products { get; set; }
        public ICollection<Offer> Offers { get; set; }


    }
}
