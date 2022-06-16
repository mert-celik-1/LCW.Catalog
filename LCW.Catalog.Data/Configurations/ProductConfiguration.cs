using LCW.Catalog.Core.Entities;
using LCW.Catalog.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCW.Catalog.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Name).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Description).IsRequired().HasMaxLength(500);
            builder.Property(a => a.CategoryId).IsRequired();
            builder.Property(a => a.Color).IsRequired();
            builder.Property(a => a.Status).IsRequired();
            builder.Property(a => a.PictureUrl).IsRequired();
            builder.Property(a => a.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(a => a.OfferedPrice).IsRequired().HasColumnType("decimal(18,2)");

            builder.HasOne<Category>(a => a.Category).WithMany(c => c.Products).HasForeignKey(a => a.CategoryId);
            builder.HasOne<User>(a => a.User).WithMany(u => u.Products).HasForeignKey(a => a.UserId);

            builder.ToTable("Products");

            builder.HasData(

                new Product { Id = Guid.NewGuid().ToString(), Name = "Kot Pantolon",Description="Yeni sezon pantolon",CategoryId="1",
                    Color=Color.Beyaz,Status=Status.Yeni,PictureUrl="default.jpg",Price=20 },
                new Product { Id = Guid.NewGuid().ToString(), Name = "Kumaş Pantolon",Description="Yeni sezon pantolon",CategoryId="1",
                    Color=Color.Siyah,Status=Status.Kullanılmış,PictureUrl="default.jpg",Price=20 },
                new Product { Id = Guid.NewGuid().ToString(), Name = "Kazak",Description="Yeni sezon kazak",CategoryId="2",
                    Color=Color.Beyaz,Status=Status.Yeni,PictureUrl="default.jpg",Price=20 }

            );
        }
    }
}
