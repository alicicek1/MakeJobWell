using MakeJobWell.Core.Entity;
using MakeJobWell.Models.Entities.HelperEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakeJobWell.Models.Entities
{
    public class Company : BaseEntity
    {
        public Company()
        {
            IsActive = true;
            PhoneNumbers = new HashSet<PhoneNumber>();
            SocialAccounts = new HashSet<SocialAccount>();
            Complaints = new HashSet<Complaint>();
        }
        public string CompanyName { get; set; }
        public string Overview { get; set; }
        public string Adress { get; set; }
        public ICollection<PhoneNumber> PhoneNumbers { get; set; }
        public string Location { get; set; }
        public string WebSite { get; set; }
        public ICollection<SocialAccount> SocialAccounts { get; set; }
        public int NumberofComplaints { get; set; }
        public int NumberofIssueResolved { get; set; }
        public int Response { get; set; }
        public decimal TrustCode { get; set; }
        public int SubCategoryID { get; set; }
        public SubCategory SubCategory { get; set; }
        public ICollection<Complaint> Complaints { get; set; }
    }
}
