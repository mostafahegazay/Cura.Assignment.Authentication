﻿using Cura.Assignment.Authentication.Domain.SeedWork;

namespace Cura.Assignment.Authentication.Domain.AggregatesModel.UserAggregate
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> AddAsync(User user);
        Task<User> FindAsync(string email);
        Task<User> FindByIdAsync(Guid id);
    }
}
