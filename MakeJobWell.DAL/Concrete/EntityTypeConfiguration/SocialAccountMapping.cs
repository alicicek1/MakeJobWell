using MakeJobWell.Models.Entities.HelperEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakeJobWell.DAL.Concrete.EntityTypeConfiguration
{
    class SocialAccountMapping : IEntityTypeConfiguration<SocialAccount>
    {
        public void Configure(EntityTypeBuilder<SocialAccount> builder)
        {
            builder.ToTable("SocialAccount");
            builder.HasKey(a => a.SocialAccountID);
            builder.Property(a => a.SocialAccountID).UseIdentityAlwaysColumn();

            builder.HasOne(a => a.Company).WithMany(a => a.SocialAccounts).HasForeignKey(a => a.CompanyID);

        }
    }
}
