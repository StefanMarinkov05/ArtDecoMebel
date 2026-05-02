using ArtDecoMebel.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ArtDecoMebel.Configuration
{
    public class AppRolesAndUsersSeedingTool
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public AppRolesAndUsersSeedingTool(RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext context)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
        }

        public async Task SeedDefaultRolesAndUsersIfEmpty()
        {
            await SeedDefaultRolesIfEmpty();
            await SeedDefaultUsersIfEmpty();
        }

        private async Task SeedDefaultRolesIfEmpty()
        {
            await SeedRoleIfEmpty(AppConfiguration.PrivilegedRoleString);
            await SeedRoleIfEmpty(AppConfiguration.UnderprivilegedRoleString);
        }

        private async Task SeedRoleIfEmpty(string roleName)
        {
            if (!await _roleManager.RoleExistsAsync(roleName))
            {
                await _roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        private async Task SeedDefaultUsersIfEmpty()
        {
            await SeedDefaultUserIfEmpty(
                AppConfiguration.DefaultPrivilegedEmail,
                AppConfiguration.PrivilegedRoleString,
                AppConfiguration.DefaultPrivilegedPassword,
                AppConfiguration.DefaultPrivilegedNickname,
                AppConfiguration.DefaultPrivilegedPhone
            );

            await SeedDefaultUserIfEmpty(
                AppConfiguration.DefaultUnderprivilegedEmail,
                AppConfiguration.UnderprivilegedRoleString,
                AppConfiguration.DefaultUnderprivilegedPassword,
                AppConfiguration.DefaultUnderprivilegedNickname,
                AppConfiguration.DefaultUnderprivilegedPhone
            );
        }

        private async Task SeedDefaultUserIfEmpty(
            string email,
            string role,
            string password,
            string nickname,
            string phoneNumber)
        {
            if (!await _userManager.Users.AnyAsync(user => user.Email == email))
            {
                var user = new ApplicationUser
                {
                    UserName = email,
                    Email = email,
                    Nickname = nickname,
                    PhoneNumber = phoneNumber,
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    if (!await _roleManager.RoleExistsAsync(role))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(role));
                    }

                    await _userManager.AddToRoleAsync(user, role);
                }
            }
        }
    }
}
