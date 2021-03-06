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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Name).IsRequired();


            builder.ToTable("Categories");

            builder.HasData(

                new Category { Id = "1", Name = "Pantolon"},
                new Category { Id = "2", Name = "Kazak"},
                new Category { Id = "3", Name = "Ayakkabı"},
                new Category { Id = "4", Name = "Mont"},
                new Category { Id = "5", Name = "Etek"}


                );

        }
    }
}
