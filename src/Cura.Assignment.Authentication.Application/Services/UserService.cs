using Cura.Assignment.Authentication.Application.Contracts.Dtos;
using Cura.Assignment.Authentication.Application.Contracts.Services;
using Cura.Assignment.Authentication.Domain.AggregatesModel.UserAggregate;
using Cura.Assignment.Authentication.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cura.Assignment.Authentication.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHashingService _hashingService;
        public UserService(IUserRepository userRepository, IHashingService hashingService)
        {
            this._userRepository = userRepository;
            this._hashingService = hashingService;
        }
        public async Task<UserDto> CreateUserAsync(CreateUpdateUserDto user)
        {
            var userEntity = new User(user.Name, user.Email);
            userEntity.SetPassword(user.Password, this._hashingService);
            userEntity = await this._userRepository.AddAsync(userEntity);
            await this._userRepository.UnitOfWork.SaveChangesAsync();
            return new UserDto()
            {
                Name = userEntity.Name,
                Email = userEntity.Email,
                CreatedAt = userEntity.CreatedAt,
                Id = userEntity.Id
            };
        }
    }
}
