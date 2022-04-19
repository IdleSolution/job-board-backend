using JobBoard.Models.Backend;
using Microsoft.AspNetCore.Identity;

namespace JobBoard.Configuration
{
    public static class ApplicationDbInitializer
    {
        public static void SeedUsers(UserManager<User> userManager)
        {
            if (userManager.FindByEmailAsync("admin@admin.com").Result==null)
            {
                User user = new User
                {
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com"
                };

                IdentityResult result = userManager.CreateAsync(user, "OsiemZnakow1!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }       
        } 
    }
}