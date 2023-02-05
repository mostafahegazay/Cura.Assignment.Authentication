using Cura.Assignment.Authentication.Domain.Exceptions;
using Cura.Assignment.Authentication.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cura.Assignment.Authentication.Domain.AggregatesModel.UserAggregate
{
    public class Permission : Entity<Guid>, IEntity
    {
        private readonly List<UserPermission> permissions;

        public string Name { get; protected set; }
        public IReadOnlyCollection<UserPermission> Permissions => permissions;
        protected Permission()
        {
            this.permissions = new List<UserPermission>();
        }

        public Permission(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new UserDomainException("Permission name can not be empty");
            }

            base.Id = Guid.NewGuid();
            Name = name;
            base.CreatedAt = DateTime.Now;
        }
    }
}
