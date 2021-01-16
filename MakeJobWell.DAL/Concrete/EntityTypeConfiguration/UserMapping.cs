using MakeJobWell.Models.Entities;
using MakeJobWell.Models.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakeJobWell.DAL.Concrete.EntityTypeConfiguration
{
    class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(a => a.ID);
            builder.Property(a => a.ID).UseIdentityAlwaysColumn();

            builder.Property(a => a.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(a => a.LastName).HasMaxLength(100).IsRequired();
            builder.Property(a => a.Email).HasMaxLength(50).IsRequired();
            builder.Property(a => a.UserName).HasMaxLength(50).IsRequired();
            builder.Property(a => a.Password).HasMaxLength(20).IsRequired();
            builder.Property(a => a.PhoneNumber).HasMaxLength(20);
            builder.Property(a => a.Address).HasMaxLength(250);

            builder.HasIndex(a => a.Email).IsUnique();
            builder.HasData(new User
            {
                ID = 1,
                FirstName = "Ali",
                LastName = "Cicek",
                Email = "alicicek@makejobwell.com",
                UserName = "alicicek",
                Password = "123",
                Gender = Gender.Man,
                UserRole = UserRole.Admin,
                IsActive = true
            });
        }
    }
}
