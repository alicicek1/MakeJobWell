using MakeJobWell.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakeJobWell.Models.Entities
{
    public class SubCategory : BaseEntity
    {
        public SubCategory()
        {
            IsActive = true;
            Companies = new HashSet<Company>();
        }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public ICollection<Company> Companies { get; set; }
    }
}
