using Cura.Assignment.Authentication.Domain.Exceptions;
using Cura.Assignment.Authentication.Domain.SeedWork;

namespace Cura.Assignment.Authentication.Domain.AggregatesModel.UserAggregate
{
    public class User : Entity<Guid>, IAggregateRoot
    {
        private readonly List<UserPermission> permissions;

        public string Email { get; protected set; }
        public string Name { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public Guid? RoleId { get; protected set; }
        public virtual Role Role { get; protected set; }
        public IReadOnlyCollection<UserPermission> Permissions => permissions;
        protected User()
        {
            this.permissions = new List<UserPermission>();
        }

        public User(string name, string email) : this()
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new UserDomainException("User email can not be empty");
            }
            if (string.IsNullOrEmpty(name))
            {
                throw new UserDomainException("User name can not be empty");
            }
            base.Id = Guid.NewGuid();
            Name = name;
            Email = email.ToLowerInvariant();
        }

        public User(string name, string email, Guid roleId) : this(name, email)
        {
            this.RoleId = roleId;
        }

        public void SetPassword(string password, IHashingService hashingService)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new UserDomainException("User password can not be empty");
            }

            this.Salt = hashingService.GetSalt(password);
            this.Password = hashingService.GetHash(password, this.Salt);
        }

        public void IsValidPassword(string password, IHashingService hashingService) => this.Password.Equals(hashingService.GetHash(password, this.Salt));

        public void SetRole(Guid roleId) => this.RoleId = roleId;
        public void SetPermission(Guid permissionId)
        {
            var existingPermssionForUser = this.permissions.Where(p => p.PermssionId == permissionId)
               .SingleOrDefault();

            if (existingPermssionForUser == null)
            {
                this.permissions.Add(new UserPermission(permissionId, base.Id));
            }
        }
        public void SetPermissions(List<Guid> permissionIds)
        {
            var permissionsToAdd = permissionIds.Where(permId => !permissions.Any(userPerm => userPerm.PermssionId == permId))
                                                .Select(permId => new UserPermission(permId, base.Id)).ToList();

            if (permissionsToAdd?.Count > 0)
            {
                this.permissions.AddRange(permissionsToAdd);
            }
        }

    }
}
