using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeJobWell.UI.MVC.Models.ViewModels
{
    public class SubCategoryVM
    {
        public SubCategoryVM()
        {
            Categories = new List<SelectListItem>();
        }
        public int SubCategoryID { get; set; }
        public string SubCategoryName { get; set; }
        public string Overview { get; set; }
        public string CatName { get; set; }
        public int CatID { get; set; }
        public List<SelectListItem> Categories { get; set; }
    }
}
