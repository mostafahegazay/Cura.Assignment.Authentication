using Cura.Assignment.Authentication.Domain.AggregatesModel.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Cura.Assignment.Authentication.Infrastructure.EntityConfigurations
{
    class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> userConfiguration)
        {
            userConfiguration.ToTable("users" + IdentityContext.DEFAULT_SCHEMA);
            userConfiguration.HasKey(b => b.Id);
            userConfiguration.Property(b => b.Name)
                .HasMaxLength(128)
                .IsRequired();
            userConfiguration.Property(b => b.Email)
                .HasMaxLength(128)
                .IsRequired();
            userConfiguration.Property(b => b.Password)
                .IsRequired();
            userConfiguration.HasIndex("Email")
                .IsUnique(true);

            userConfiguration.HasMany(b => b.Permissions)
               .WithOne(k => k.User)
               .HasForeignKey(f => f.UserId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
