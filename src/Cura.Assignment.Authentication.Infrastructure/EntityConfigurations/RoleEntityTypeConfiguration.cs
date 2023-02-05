using Cura.Assignment.Authentication.Domain.AggregatesModel.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cura.Assignment.Authentication.Infrastructure.EntityConfigurations
{
    public class RoleEntityTypeConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> userConfiguration)
        {
            userConfiguration.ToTable("Roles" + IdentityContext.DEFAULT_SCHEMA);
            userConfiguration.HasKey(b => b.Id);
            userConfiguration.Property(b => b.Name)
                .HasMaxLength(128)
                .IsRequired();

            userConfiguration.HasMany(b => b.Users)
               .WithOne(k => k.Role)
               .HasForeignKey(f => f.RoleId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
