using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeJobWell.UI.MVC.Models.ViewModels
{
    public class CommentInsertVM
    {
        public string CommentText { get; set; }
        public int ComplaintID { get; set; }
        public int UserID { get; set; }
    }
}
