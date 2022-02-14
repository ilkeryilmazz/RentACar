using Core.Entities;

namespace Core.Entites.Concrete
{
    public class UserOperationClaim:IEntity
    {
        public int Id{ get; set; }
        public int UserId{ get; set; }
        public int OperationClaimId{ get; set; }
    }
}