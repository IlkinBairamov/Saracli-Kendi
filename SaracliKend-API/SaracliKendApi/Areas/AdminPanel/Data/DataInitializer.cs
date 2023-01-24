using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SaracliKend.Database.Context;
using SaracliKend.Domain.Entities;

namespace SaracliKendApi.Areas.AdminPanel.Data
{
    public class DataInitializer
    {
        private readonly SaracliDbContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;

        public DataInitializer(SaracliDbContext dbContext, RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task SeedData()
        {
            await _dbContext.Database.MigrateAsync();

            var roles = new List<string>
            {
                "Admin"
            };
            var admin = new User
            {
                FullName = "Admin",
                UserName = "admin123",
                Email = "admin123@code.az"
            };

            foreach (var role in roles)
            {
                if (await _roleManager.RoleExistsAsync(role))
                    continue;
                await _roleManager.CreateAsync(new IdentityRole(role));
            };

            if (await _userManager.FindByNameAsync(admin.UserName) != null)
                return;

            await _userManager.CreateAsync(admin, "Admin.123");
            await _userManager.AddToRoleAsync(admin, "Admin");
        }
    }
}
