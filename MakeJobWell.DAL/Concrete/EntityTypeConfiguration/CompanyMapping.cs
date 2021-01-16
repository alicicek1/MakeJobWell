using MakeJobWell.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakeJobWell.DAL.Concrete.EntityTypeConfiguration
{
    class CompanyMapping : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Company");
            builder.HasKey(a => a.ID);
            builder.Property(a => a.ID).UseIdentityAlwaysColumn();

            builder.Property(a => a.CompanyName).HasMaxLength(100).IsRequired();
            builder.Property(a => a.Overview).HasMaxLength(250).IsRequired();
            builder.Property(a => a.Adress).HasMaxLength(100).IsRequired();
            builder.Property(a => a.Location).HasMaxLength(30).IsRequired();
            builder.Property(a => a.WebSite).IsRequired();
            builder.Property(a => a.NumberofComplaints).HasDefaultValueSql("0");
            builder.Property(a => a.NumberofIssueResolved).HasDefaultValueSql("0");
            builder.Property(a => a.Response).HasDefaultValueSql("0");
            builder.Property(a => a.TrustCode).HasPrecision(2, 3);

            //builder.Property(a => a.SocialAccounts).ValueGeneratedOnAddOrUpdate();
            builder.HasMany(a => a.SocialAccounts).WithOne(a => a.Company);
            //builder.Property(a => a.PhoneNumbers).ValueGeneratedOnAddOrUpdate();
            builder.HasMany(a => a.PhoneNumbers).WithOne(a => a.Company);

        }
    }
}
