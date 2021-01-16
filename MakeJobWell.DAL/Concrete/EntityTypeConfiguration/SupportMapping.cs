using MakeJobWell.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakeJobWell.DAL.Concrete.EntityTypeConfiguration
{
    class SupportMapping : IEntityTypeConfiguration<Support>
    {
        public void Configure(EntityTypeBuilder<Support> builder)
        {
            builder.ToTable("Support");
            builder.HasKey(a => new { a.ComplaintID, a.UserID });
        }
    }
}
