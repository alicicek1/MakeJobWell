using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MakeJobWell.Models.Entities.HelperEntities
{
    public class PhoneNumber
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short Number { get; set; }
        public string Country { get; set; }
        public string Info { get; set; }
        public int CompanyID { get; set; }
        public Company Company { get; set; }
    }
}
