using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeJobWell.UI.MVC.Models.ViewModels
{
    public class ComplaintUserCommentVM
    {
        public int ComplaintID { get; set; }
        public string UserName { get; set; }
        public string Comment { get; set; }
    }
}
