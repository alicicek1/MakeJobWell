using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeJobWell.Service.WebAPI.Models
{
    public class ComplaintDTO
    {
        public ComplaintDTO()
        {
            Companies = new HashSet<SelectListItem>();
        }
        public int ComplaintID { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public int UserID { get; set; }
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public ICollection<SelectListItem> Companies { get; set; }
        public string ComplaintProofFile { get; set; }
        public string IncoiceProofFile { get; set; }
    }
}
