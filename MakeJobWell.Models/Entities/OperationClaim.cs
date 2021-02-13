using MakeJobWell.Core.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakeJobWell.Models.Entities
{
    [Table("OperationClaim")]
    public class OperationClaim : IEntity
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        public ICollection<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
