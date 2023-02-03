using Cura.Assignment.Authentication.Domain.Application;
using Cura.Assignment.Authentication.Domain.Exceptions;
using Cura.Assignment.Authentication.Domain.SeedWork;

namespace Cura.Assignment.Authentication.Domain.AggregatesModel.UserAggregate
{
    public class User : Entity<Guid>, IAggregateRoot
    {
        public string Email { get; protected set; }
        public string Name { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        protected User()
        {

        }

        public User(string name, string email)
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
            CreatedAt = DateTime.Now;
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

    }
}
