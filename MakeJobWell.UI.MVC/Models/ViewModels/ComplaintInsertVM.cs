using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeJobWell.UI.MVC.Models.ViewModels
{
    public class ComplaintInsertVM
    {
        public ComplaintInsertVM()
        {
            Companies = new HashSet<SelectListItem>();
        }
        public string Title { get; set; }
        public string Detail { get; set; }
        public int UserID { get; set; }
        public int CompanyID { get; set; }
        public ICollection<SelectListItem> Companies { get; set; }
        public string ComplaintProofFile { get; set; }
        public string IncoiceProofFile { get; set; }

    }
}
