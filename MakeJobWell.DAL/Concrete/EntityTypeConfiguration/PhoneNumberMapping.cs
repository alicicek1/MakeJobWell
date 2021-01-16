using MakeJobWell.Models.Entities.HelperEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakeJobWell.DAL.Concrete.EntityTypeConfiguration
{
    class PhoneNumberMapping : IEntityTypeConfiguration<PhoneNumber>
    {
        public void Configure(EntityTypeBuilder<PhoneNumber> builder)
        {
            builder.ToTable("PhoneNumber");
            builder.HasKey(a => a.Number);
            builder.Property(a => a.Number).UseIdentityAlwaysColumn();


            builder.Property(a => a.Info).HasMaxLength(20).IsRequired();
            builder.Property(a => a.Country).IsRequired();

            builder.HasOne(a => a.Company).WithMany(a => a.PhoneNumbers).HasForeignKey(a => a.CompanyID);
        }
    }
}
