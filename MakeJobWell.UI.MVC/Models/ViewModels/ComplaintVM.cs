using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeJobWell.UI.MVC.Models.ViewModels
{
    public class ComplaintVM
    {
        public int ComplaintID { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public string SubCategoryName { get; set; }
    }
}
