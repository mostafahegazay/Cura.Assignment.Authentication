using Cura.Assignment.Authentication.Domain.AggregatesModel.UserAggregate;
using Cura.Assignment.Authentication.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cura.Assignment.Authentication.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IdentityContext _context;
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public RoleRepository(IdentityContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Role> AddAsync(Role role)
        {
            var entry = await _context.Roles
                            .AddAsync(role);

            return entry.Entity;
        }

        public async Task<Role> FindAsync(string name)
        {
            var role = await _context.Roles
                .Where(b => b.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) > -1)
                .SingleOrDefaultAsync();

            return role;
        }

        public async Task<Role> FindByIdAsync(Guid id)
        {
            var role = await _context.Roles
               .Where(b => b.Id == id)
               .SingleOrDefaultAsync();

            return role;
        }
    }
}
