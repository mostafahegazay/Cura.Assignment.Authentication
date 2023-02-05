using Cura.Assignment.Authentication.Domain.AggregatesModel.UserAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cura.Assignment.Authentication.Infrastructure.EntityConfigurations
{
    public class UserPermissionEntityTypeConfiguration : IEntityTypeConfiguration<UserPermission>
    {
        public void Configure(EntityTypeBuilder<UserPermission> userConfiguration)
        {
            userConfiguration.ToTable("permissions" + IdentityContext.DEFAULT_SCHEMA);
            userConfiguration.HasKey(b => b.Id);
        }
    }
}
