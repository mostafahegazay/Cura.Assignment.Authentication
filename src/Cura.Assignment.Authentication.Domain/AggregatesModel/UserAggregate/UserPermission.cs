using Cura.Assignment.Authentication.Domain.SeedWork;

namespace Cura.Assignment.Authentication.Domain.AggregatesModel.UserAggregate
{
    public class UserPermission : Entity<Guid>, IEntity
    {
        public Guid UserId { get; protected set; }
        public Guid PermssionId { get; protected set; }
        public virtual User User { get; protected set; }
        public virtual Permission Permission { get; protected set; }
        public UserPermission()
        {

        }
        public UserPermission(Guid permissionId, Guid userId)
        {
            base.Id = Guid.NewGuid();
            this.PermssionId = permissionId;
            this.UserId = userId;
        }
    }
}
