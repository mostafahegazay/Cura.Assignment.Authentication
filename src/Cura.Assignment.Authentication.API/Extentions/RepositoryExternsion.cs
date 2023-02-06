using Cura.Assignment.Authentication.Application.Contracts.Handlers;
using Cura.Assignment.Authentication.Application.Handlers;
using Cura.Assignment.Authentication.Domain.AggregatesModel.UserAggregate;
using Cura.Assignment.Authentication.Infrastructure.Repositories;

namespace Cura.Assignment.Authentication.API.Extentions
{
    public static class RepositoryExternsion
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
        }
    }
}
