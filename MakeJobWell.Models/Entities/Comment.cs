using MakeJobWell.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakeJobWell.Models.Entities
{
    public class Comment : BaseEntity
    {
        public Comment()
        {
            IsActive = true;
        }
        public string CommentText { get; set; }
        public int ComplaintID { get; set; }
        public int UserID { get; set; }
        public Complaint Complaint { get; set; }
        public User User { get; set; }
    }
}
