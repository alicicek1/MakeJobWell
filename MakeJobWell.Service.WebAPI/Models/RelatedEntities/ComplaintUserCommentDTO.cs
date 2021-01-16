using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeJobWell.Service.WebAPI.Models.RelatedEntities
{
    public class ComplaintUserCommentDTO
    {
        public ComplaintUserCommentDTO()
        {
            Comments = new HashSet<string>();
        }
        public int ComplaintID { get; set; }
        public string UserName { get; set; }
        public ICollection<string> Comments { get; set; }
    }
}
