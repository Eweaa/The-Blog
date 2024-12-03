using Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace Core.Contexts;

public class ContextSeed
{
    public static async Task SeedAsync(ApplicationDbContext context, UserManager<AppUser> userManager)
    {
        if (!userManager.Users.Any())
        {
            var user = new AppUser()
            {
                DisplayName = "MM",
                Email = "MM@gmail.com",
                EmailConfirmed = true,
                UserName = "MM",
                PhoneNumber = "01003322541"
            };
            await userManager.CreateAsync(user, "Mm123?");
        }
        
        // if (!context.Articles.Any())
        // {
        //     List<Article> articles =
        //     [
        //         new Article() { Title = "Is Succession the best Tv Show Ever Made?", Content = "", Date = DateTime.Now },
        //         new Article() { Title = "Why I dont' write poetry", Content = "", Date = DateTime.Now },
        //         new Article() { Title = "What I wish they would invent", Content = "", Date = DateTime.Now }
        //     ];
        //     context.Articles.AddRange(articles);
        // }
        
        await context.SaveChangesAsync();
    }
}