using Cura.Assignment.Authentication.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cura.Assignment.Authentication.Domain.AggregatesModel.UserAggregate
{
    public interface IPermissionRepository : IRepository<Permission>
    {
        Task<Permission> AddAsync(Permission permission);
        Task<Permission> FindAsync(string name);
        Task<Permission> FindByIdAsync(Guid id);
    }
}
