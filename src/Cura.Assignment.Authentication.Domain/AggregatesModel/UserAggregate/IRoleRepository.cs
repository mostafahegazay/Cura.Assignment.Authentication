using Cura.Assignment.Authentication.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cura.Assignment.Authentication.Domain.AggregatesModel.UserAggregate
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task<Role> AddAsync(Role role);
        Task<Role> FindAsync(string name);
        Task<Role> FindByIdAsync(Guid id);
    }
}
