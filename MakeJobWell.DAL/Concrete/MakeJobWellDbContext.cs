using MakeJobWell.DAL.Concrete.EntityTypeConfiguration;
using MakeJobWell.Models.Entities;
using MakeJobWell.Models.Entities.HelperEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakeJobWell.DAL.Concrete
{
    class MakeJobWellDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("User ID=postgres; Database=MakeJobWellDb; Password=123; Server=localhost");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Support> Supports { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<SocialAccount> SocialAccountsk { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMapping());
            modelBuilder.ApplyConfiguration(new SubCategoryMapping());
            modelBuilder.ApplyConfiguration(new CompanyMapping());
            modelBuilder.ApplyConfiguration(new ComplaintMapping());
            modelBuilder.ApplyConfiguration(new CommentMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new SupportMapping());
            modelBuilder.ApplyConfiguration(new PhoneNumberMapping());
            modelBuilder.ApplyConfiguration(new SocialAccountMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
