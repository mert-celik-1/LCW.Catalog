using LCW.Catalog.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LCW.Catalog.Core.Entities
{
    public class Product:BaseEntity
    {
        public bool OfferOption { get; set; } = false;
        public string PictureUrl { get; set; } = "default.jpg";
        public string Description { get; set; }
        public Color Color { get; set; }
        public Brand Brand { get; set; }
        public Status Status { get; set; }
        public bool IsSold { get; set; }
        public decimal Price { get; set; }
        public decimal OfferedPrice { get; set; } 
        public bool IsOfferable { get; set; }
        public string CategoryId { get; set; }
        public Category Category { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public ICollection<Offer> Offers { get; set; }

    }
}
