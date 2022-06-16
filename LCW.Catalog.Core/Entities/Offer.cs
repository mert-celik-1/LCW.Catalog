using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCW.Catalog.Core.Entities
{
    public class Offer:BaseEntity
    {
        public decimal OfferedPrice { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string ProductId { get; set; }
        public Product Product { get; set; }
    }
}
