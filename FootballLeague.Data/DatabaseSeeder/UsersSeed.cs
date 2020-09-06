using FootballLeague.Data.Entities;
using FootballLeague.Data.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace FootballLeague.Data.DatabaseSeeder
{
    public static class UsersSeed
    {
        public static void UpdateUsers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>()
                .HasData(new IdentityRole { Name = "admin", Id = "1", NormalizedName = "admin".ToUpper() });

            modelBuilder.Entity<IdentityRole>()
                .HasData(new IdentityRole { Name = "user", Id = "2", NormalizedName = "user".ToUpper() });

            var admin = SeedAdmin();
            var user = SeedUser();

            modelBuilder.Entity<User>()
                .HasData(admin);

            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasData(new IdentityUserRole<string>
                {
                    RoleId = "1",
                    UserId = admin.Id
                });

            modelBuilder.Entity<User>()
                .HasData(user);

            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasData(new IdentityUserRole<string>
                {
                    RoleId = "2",
                    UserId = user.Id
                });
        }

        private static User SeedAdmin()
        {
            var adminUser = new User
            {
                Id = "1",
                UserName = "admin",
                NormalizedUserName = "admin".ToUpper(),
                Email = "admin@abv.bg",
                NormalizedEmail = "admin@abv.bg".ToUpper(),
                EmailConfirmed = true,
                PhoneNumber = "+111111111",
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                Role = UserRoles.admin
            };

            var hashePass = new PasswordHasher<User>().HashPassword(adminUser, "admin");
            adminUser.PasswordHash = hashePass;

            return adminUser;
        }

        private static User SeedUser()
        {
            var user = new User
            {
                Id = "2",
                UserName = "user",
                NormalizedUserName = "user".ToUpper(),
                Email = "user@abv.bg",
                NormalizedEmail = "user@abv.bg".ToUpper(),
                EmailConfirmed = true,
                PhoneNumber = "+0895674532",
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                Role = UserRoles.user
            };

            var hashePass = new PasswordHasher<User>().HashPassword(user, "user");
            user.PasswordHash = hashePass;

            return user;
        }
    }
}
