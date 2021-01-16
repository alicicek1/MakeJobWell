using MakeJobWell.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakeJobWell.DAL.Concrete.EntityTypeConfiguration
{
    class ComplaintMapping : IEntityTypeConfiguration<Complaint>
    {
        public void Configure(EntityTypeBuilder<Complaint> builder)
        {
            builder.ToTable("Complaint");
            builder.HasKey(a => a.ID);
            builder.Property(a => a.ID).UseIdentityAlwaysColumn();

            builder.Property(a => a.ComplaintTitle).HasMaxLength(40).IsRequired();
            builder.Property(a => a.ComplaintDetail).HasMaxLength(250).IsRequired();

        }
    }
}
