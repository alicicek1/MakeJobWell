using System.ComponentModel.DataAnnotations.Schema;

namespace MakeJobWell.Core.Entity.Concrete
{
    [Table("OperationClaim")]
    public class OperationClaim : IEntity
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Name")]
        public string Name { get; set; }
    }
}
