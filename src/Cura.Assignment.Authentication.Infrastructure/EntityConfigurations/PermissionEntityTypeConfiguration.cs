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
    public class PermissionEntityTypeConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> userConfiguration)
        {
            userConfiguration.ToTable("Permissions" + IdentityContext.DEFAULT_SCHEMA);
            userConfiguration.HasKey(b => b.Id);
            userConfiguration.Property(b => b.Name)
                .HasMaxLength(128)
                .IsRequired();

            userConfiguration.HasMany(b => b.Permissions)
               .WithOne(k => k.Permission)
               .HasForeignKey(f => f.PermssionId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
