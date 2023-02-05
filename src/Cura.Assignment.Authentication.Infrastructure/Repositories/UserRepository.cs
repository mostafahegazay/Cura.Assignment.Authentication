using Cura.Assignment.Authentication.Domain.AggregatesModel.UserAggregate;
using Cura.Assignment.Authentication.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace Cura.Assignment.Authentication.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IdentityContext _context;
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public UserRepository(IdentityContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<User> AddAsync(User user)
        {
            var entry = await _context.Users
                            .AddAsync(user);

            return entry.Entity;
        }

        public async Task<User> FindAsync(string email)
        {
            var user = await _context.Users
                .Where(b => b.Email == email.ToLowerInvariant())
                .SingleOrDefaultAsync();

            return user;
        }

        public async Task<User> FindByIdAsync(Guid id)
        {
            var user = await _context.Users
                .Where(b => b.Id == id)
                .SingleOrDefaultAsync();

            return user;
        }
    }
}
