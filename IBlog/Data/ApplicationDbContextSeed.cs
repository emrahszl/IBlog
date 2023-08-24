using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IBlog.Data
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedAsync(ApplicationDbContext db, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            var adminEmail = "admin@example.com";
            var adminPassword = "P@ssword1";
            var adminRoleName = "Administrator";

            if (await userManager.Users.AnyAsync(u => u.UserName == adminEmail) || await roleManager.RoleExistsAsync(adminRoleName))
                return;

            var adminUser = new IdentityUser()
            {
                UserName = adminEmail,
                Email = adminEmail,
                EmailConfirmed = true
            };

            await userManager.CreateAsync(adminUser, adminPassword);
            await roleManager.CreateAsync(new IdentityRole(adminRoleName));
            await userManager.AddToRoleAsync(adminUser, adminRoleName);

            List<Post> posts = new List<Post>
            {
                new Post
                {
                    Title = "Enchanted by the Elegance of Wild Horses",
                    Content = "A graceful spectacle of untamed beauty across vast open landscapes. Witnessing the untethered spirit of wild horses is a true marvel of the natural world.",
                    ImageName = "1.jpg",
                    AuthorId = adminUser.Id
                },
                new Post
                {
                    Title = "Captivated by the Dance of the Northern Lights",
                    Content = "A mesmerizing display of colors across the Arctic skies. Nature's masterpiece at its finest.",
                    ImageName = "2.jpg",
                    AuthorId = adminUser.Id
                },
                new Post
                {
                    Title = "Redefining Strength: Conquering the Weight Room",
                    Content = "Determination knows no bounds. Witnessing a man's dedication as he lifts his aspirations along with the weights.",
                    ImageName = "3.jpg",
                    AuthorId = adminUser.Id
                }
            };

            db.AddRange(posts);
            await db.SaveChangesAsync();
        }
    }
}
