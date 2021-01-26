using MakeJobWell.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakeJobWell.Models.Entities
{
    public class Support : BaseEntity
    {
        public int UserID { get; set; }
        public int ComplaintID { get; set; }
        public int SupportCounter { get; set; }
        public User User { get; set; }
        public Complaint Complaint { get; set; }
    }
}
