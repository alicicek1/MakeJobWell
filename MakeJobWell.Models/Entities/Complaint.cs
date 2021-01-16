using MakeJobWell.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakeJobWell.Models.Entities
{
    public class Complaint : BaseEntity
    {
        public Complaint()
        {
            IsActive = true;
            Comments = new HashSet<Comment>();
            Supports = new HashSet<Support>();
        }
        public string ComplaintTitle { get; set; }
        public string ComplaintDetail { get; set; }
        public string ComplaintProofUrl { get; set; }
        public string ComplaintInvoiceUrl { get; set; }
        public int UserID { get; set; }
        public int CompanyID { get; set; }
        public User User { get; set; }
        public Company Company { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Support> Supports { get; set; }
    }
}
