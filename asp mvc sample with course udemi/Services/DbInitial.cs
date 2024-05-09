
using Microsoft.AspNetCore.Identity;

namespace asp_mvc_sample_with_course_udemi.Services
{
    public class DbInitial : IDbInitial
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitial(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedData()
        {
            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
                var user = new IdentityUser { UserName = "admin@gmail.com", Email = "admin@gmail.com" };
                await _userManager.CreateAsync(user, "Admin@1234");
                await _userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}