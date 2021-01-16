using MakeJobWell.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakeJobWell.DAL.Concrete.EntityTypeConfiguration
{
    class CommentMapping : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comment");
            builder.HasKey(a => new { a.UserID, a.ComplaintID });
            builder.Property(a => a.ID).UseIdentityAlwaysColumn();

            builder.Property(a => a.CommentText).HasMaxLength(100);
        }
    }
}
