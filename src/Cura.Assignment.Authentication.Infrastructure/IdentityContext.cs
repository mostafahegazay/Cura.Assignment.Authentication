using Cura.Assignment.Authentication.Domain.AggregatesModel.UserAggregate;
using Cura.Assignment.Authentication.Domain.SeedWork;
using Cura.Assignment.Authentication.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Threading;

namespace Cura.Assignment.Authentication.Infrastructure
{
    public class IdentityContext : DbContext, IUnitOfWork
    {
        public const string DEFAULT_SCHEMA = "Identity";
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }

        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options) { }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RoleEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserPermissionEntityTypeConfiguration());
        }
    }
}
