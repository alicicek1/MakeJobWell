using System;
using System.Collections.Generic;
using System.Text;

namespace MakeJobWell.Models.Entities.HelperEntities
{
    public class SocialAccount
    {
        public int SocialAccountID { get; set; }
        public string Platform { get; set; }
        public string AccountUrl { get; set; }
        public int CompanyID { get; set; }
        public Company Company { get; set; }
    }
}
