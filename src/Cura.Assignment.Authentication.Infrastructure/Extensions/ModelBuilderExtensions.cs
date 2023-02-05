using Cura.Assignment.Authentication.Domain.AggregatesModel.UserAggregate;
using Cura.Assignment.Authentication.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace Cura.Assignment.Authentication.Infrastructure.Extensions
{
    public static class ModelBuilderExtensions
    {
        
        public static void Seed(this ModelBuilder modelBuilder, IHashingService hashingService)
        {
            //Role
            var adminRole = new Role("admin");
            modelBuilder.Entity<Role>()
                        .HasData(
                         adminRole,
                         new Role("player"));

            //Permission
            var vipPermission = new Permission("vip_chararacter_personalize");
            var gamePermission = new Permission("b_game");
            modelBuilder.Entity<Permission>()
                        .HasData(
                         gamePermission,
                         vipPermission);

            //User
            var adminUser = new User("Mostafa Emad", "mostafa.emad@hotmail.com", adminRole.Id);
            adminUser.SetPassword("P@ssw0rdL0g", hashingService);
            modelBuilder.Entity<User>()
                       .HasData(adminUser);

            //User Permissions
            modelBuilder.Entity<UserPermission>()
                       .HasData(
                            new UserPermission(vipPermission.Id, adminUser.Id),
                            new UserPermission(gamePermission.Id, adminUser.Id));
        }
    }
}
