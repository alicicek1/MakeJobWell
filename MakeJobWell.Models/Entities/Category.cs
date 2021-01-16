using MakeJobWell.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakeJobWell.Models.Entities
{
    public class Category : BaseEntity
    {
        public Category()
        {
            IsActive = true;
            SubCategories = new HashSet<SubCategory>();
        }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public ICollection<SubCategory> SubCategories { get; set; }
    }
}
