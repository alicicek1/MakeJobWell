using System;
using System.Collections.Generic;
using System.Text;

namespace MakeJobWell.Core.Entity
{
    public class BaseEntity
    {
        public int ID { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
