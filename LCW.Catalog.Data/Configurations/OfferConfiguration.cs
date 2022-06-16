using LCW.Catalog.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCW.Catalog.Data.Configurations
{
    public class OfferConfiguration : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.OfferedPrice).HasColumnType("decimal(18,2)");

            builder.HasOne<Product>(a => a.Product).WithMany(c => c.Offers).HasForeignKey(a => a.ProductId);
            builder.HasOne<User>(a => a.User).WithMany(u => u.Offers).HasForeignKey(a => a.UserId);

            builder.ToTable("Offers");

            builder.HasData(

                new Offer { Id = Guid.NewGuid().ToString(),Name="Offer test" }


                );

        }
    }
}
