using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Training_Management.Models;
using TrainingManagement.Constants;

namespace Training_Management.Data
{
    public static class DBSeeder
    {

        public static IHost SeedDb(this IHost webHost)
        {
            using (var scope = webHost.Services.CreateScope())
            {
                try
                {
                    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();


                    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                    userManager.SeedUsers(context).Wait();
                    context.Database.Migrate();

                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex.Message);
                    //throw;
                }
            }
            return webHost;
        }


        public static async Task SeedUsers(this UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            if (await userManager.Users.AnyAsync()) return;

            byte[] default_Image = File.ReadAllBytes(Constant.DefaultImage.path + Constant.DefaultImage.File);
            var user_SuperAdmin = new ApplicationUser
            {


                CreatedAt = DateTime.Now,
                UserName = "Superadmin",
                Email = "Superadmin@gmail.com",
                IsDelete = false,
                EmailConfirmed = true,
            };
            var user_Adviser = new ApplicationUser
            {
                CreatedAt = DateTime.Now,
                UserName = "Adviser",
                Email = "Adviser@gmail.com",
                IsDelete = false,
                EmailConfirmed = true,
            };
            var user_Trainee = new ApplicationUser
            {
                CreatedAt = DateTime.Now,
                UserName = "Trainee",
                Email = "Trainee@gmail.com",
                IsDelete = false,
                EmailConfirmed = true,
            }; var user_Manager = new ApplicationUser
            {
                CreatedAt = DateTime.Now,
                UserName = "Manager",
                Email = "Manager@gmail.com",
                IsDelete = false,
                EmailConfirmed = true,
            };
            await userManager.CreateAsync(user_Trainee, "123321");
            await userManager.CreateAsync(user_Manager, "123321");
            await userManager.CreateAsync(user_Adviser, "123321");
            await userManager.CreateAsync(user_SuperAdmin, "123321");

            await userManager.AddToRoleAsync(user_SuperAdmin, "SuperAdmin");
            await userManager.AddToRoleAsync(user_Trainee, "Trainee");
            await userManager.AddToRoleAsync(user_Manager, "Manager");
            await userManager.AddToRoleAsync(user_Adviser, "Adviser");



        }
    }
}
