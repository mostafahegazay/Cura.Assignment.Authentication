using Cura.Assignment.Authentication.Domain.AggregatesModel.UserAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Cura.Assignment.Authentication.Infrastructure.EntityConfigurations
{
    public class UserPermissionEntityTypeConfiguration : IEntityTypeConfiguration<UserPermission>
    {
        public void Configure(EntityTypeBuilder<UserPermission> userConfiguration)
        {
            userConfiguration.ToTable("UserPermissions" + IdentityContext.DEFAULT_SCHEMA);
            userConfiguration.HasKey(b => b.Id);
        }
    }
}
