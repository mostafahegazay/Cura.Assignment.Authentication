using Cura.Assignment.Authentication.Domain.Exceptions;
using Cura.Assignment.Authentication.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cura.Assignment.Authentication.Domain.AggregatesModel.UserAggregate
{
    public class Role : Entity<Guid>, IEntity
    {
        private readonly List<User> users;

        public string Name { get; protected set; }
        public IReadOnlyCollection<User> Users => users;
        protected Role()
        {
            this.users = new List<User>();
        }

        public Role(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new UserDomainException("Role name can not be empty");
            }
          
            base.Id = Guid.NewGuid();
            Name = name;
            base.CreatedAt = DateTime.Now;
        }

    }
}
