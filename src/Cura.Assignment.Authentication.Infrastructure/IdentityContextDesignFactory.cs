using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Cura.Assignment.Authentication.Infrastructure
{
    public class IdentityContextDesignFactory : IDesignTimeDbContextFactory<IdentityContext>
    {
        public IdentityContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var optionsBuilder = new DbContextOptionsBuilder<IdentityContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new IdentityContext(optionsBuilder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Cura.Assignment.Authentication.API/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
