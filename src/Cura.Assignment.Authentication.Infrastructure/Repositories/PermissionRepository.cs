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
    public class PermissionRepository : IPermissionRepository
    {
        private readonly IdentityContext _context;
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public PermissionRepository(IdentityContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Permission> AddAsync(Permission permission)
        {
            var entry = await _context.Permissions
                            .AddAsync(permission);

            return entry.Entity;
        }

        public async Task<Permission> FindAsync(string name)
        {
            var permission = await _context.Permissions
                .Where(b => b.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) > -1)
                .SingleOrDefaultAsync();

            return permission;
        }

        public async Task<Permission> FindByIdAsync(Guid id)
        {
            var permission = await _context.Permissions
               .Where(b => b.Id == id)
               .SingleOrDefaultAsync();

            return permission;
        }
    }
}
