using System.ComponentModel.DataAnnotations.Schema;

namespace MakeJobWell.Core.Entity.Concrete
{
    [Table("UserOperationClaim")]
    public class UserOperationClaim : IEntity
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("UserID")]
        public int UserID { get; set; }
        [Column("OperationClaimId")]
        public int OperationClaimId { get; set; }

        [ForeignKey("OperationClaimId")]
        public OperationClaim OperationClaim { get; set; }
    }
}
