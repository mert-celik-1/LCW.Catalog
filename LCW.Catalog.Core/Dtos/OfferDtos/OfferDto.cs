using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCW.Catalog.Core.Dtos.OfferDtos
{
    public class OfferDto
    {
        public decimal OfferedPrice { get; set; }
        public string UserId { get; set; }
        public string ProductId { get; set; }
    }
}
