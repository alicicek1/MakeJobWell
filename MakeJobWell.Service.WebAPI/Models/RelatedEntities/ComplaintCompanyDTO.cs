using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeJobWell.Service.WebAPI.Models.RelatedEntities
{
    public class ComplaintCompanyDTO
    {
        public int ComplaintID { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public string CompanyName { get; set; }
    }
}
