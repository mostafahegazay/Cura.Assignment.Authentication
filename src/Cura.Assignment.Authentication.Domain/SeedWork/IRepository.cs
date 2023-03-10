using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cura.Assignment.Authentication.Domain.SeedWork
{
    public interface IRepository<T> where T : IEntity
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
