using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeJobWell.Service.WebAPI.Models.RelatedEntities
{
    public class CommentInsertDTO
    {
        public string CommentText { get; set; }
        public int ComplaintID { get; set; }
        public int UserID { get; set; }
    }
}
