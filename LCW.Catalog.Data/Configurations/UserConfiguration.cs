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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {

       
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.PasswordHash).IsRequired();

            builder.ToTable("AspNetUsers");

        }
    }
}
