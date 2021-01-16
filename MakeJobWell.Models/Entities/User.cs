using MakeJobWell.Core.Entity;
using MakeJobWell.Models.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakeJobWell.Models.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
            IsActive = false;
            Comments = new HashSet<Comment>();
            Complaints = new HashSet<Complaint>();
            Supports = new HashSet<Support>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public UserRole UserRole { get; set; }
        public Gender Gender { get; set; }
        public Guid ActivationCode { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Complaint> Complaints { get; set; }
        public ICollection<Support> Supports { get; set; }
    }
}
