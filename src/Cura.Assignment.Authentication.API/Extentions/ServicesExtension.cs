using Cura.Assignment.Authentication.Application.Contracts.Services;
using Cura.Assignment.Authentication.Application.Services;
using Cura.Assignment.Authentication.Domain.AggregatesModel.UserAggregate;
using Cura.Assignment.Authentication.Domain.SeedWork;
using Cura.Assignment.Authentication.Infrastructure.Repositories;

namespace Cura.Assignment.Authentication.API.Extentions
{
    public static class ServicesExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IHashingService, HashingService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IIdentityService, IdentityService>();
        }
    }
}
