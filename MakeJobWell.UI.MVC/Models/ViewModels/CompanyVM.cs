using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeJobWell.UI.MVC.Models.ViewModels
{
    public class CompanyVM
    {
        public CompanyVM()
        {
            SubCategories = new List<SelectListItem>();
        }
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string Overview { get; set; }
        public string Location { get; set; }
        public string WebSite { get; set; }
        public int SubCatID { get; set; }
        public List<SelectListItem> SubCategories { get; set; }
    }
}
