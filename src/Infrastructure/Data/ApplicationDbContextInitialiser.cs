using System.Runtime.InteropServices;
using BlogApp.Domain.Constants;
using BlogApp.Domain.Entities;
using BlogApp.Infrastructure.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BlogApp.Infrastructure.Data;

public static class InitialiserExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();

        await initialiser.InitialiseAsync();

        await initialiser.SeedAsync();
    }
}

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // Default roles
        var administratorRole = new IdentityRole(Roles.Administrator);

        if (_roleManager.Roles.All(r => r.Name != administratorRole.Name))
        {
            await _roleManager.CreateAsync(administratorRole);
        }

        // Default users
        var administrator = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

        if (_userManager.Users.All(u => u.UserName != administrator.UserName))
        {
            await _userManager.CreateAsync(administrator, "Administrator1!");
            if (!string.IsNullOrWhiteSpace(administratorRole.Name))
            {
                await _userManager.AddToRolesAsync(administrator, new [] { administratorRole.Name });
            }
        }

        // Default data
        // Seed, if necessary
        if (!_context.TodoLists.Any())
        {
            _context.TodoLists.Add(new TodoList
            {
                Title = "Todo List",
                Items =
                {
                    new TodoItem { Title = "Make a todo list 📃" },
                    new TodoItem { Title = "Check off the first item ✅" },
                    new TodoItem { Title = "Realise you've already done two things on the list! 🤯"},
                    new TodoItem { Title = "Reward yourself with a nice, long nap 🏆" },
                }
            });

        }

        if (!_context.Articles.Any())
        {
            var Articles = new List<Article>()
            {
                new Article(){ WriterId = 5, Date = DateTime.Now, Title = "Why Succession is the best Tv show ever", Content = "Why Succession is the best Tv show everWhy Succession is the best Tv show everWhy Succession is the best Tv show everWhy Succession is the best Tv show everWhy Succession is the best Tv show ever"},
                new Article(){ WriterId = 6, Date = DateTime.Now, Title = "Is MCU Cinema?", Content = "Martin Scorsese, the renowned director, has expressed his critique of the Marvel Cinematic Universe (MCU) and comic book franchise culture. He emphasizes the 'potentially negative' impact it has on audiences less exposed to diverse forms of cinema¹. In an op-ed, Scorsese explains his criticisms of the MCU. He maintains that for him, \"cinema was about revelation — aesthetic, emotional and spiritual revelation. It was about characters — the complexity of people and their contradictory and sometimes paradoxical natures, the way they can hurt one another and love one another and suddenly come face to face with themselves.\" And for him, he simply doesn't think that the Marvel movies encapsulate those criteria⁴. He further drove his point by focusing on the films' formulaic format⁴. Scorsese's outlook comes purely from his own \"personal taste and temperament,\" even admitting that, if circumstances were a little different, that opinion might be dramatically different⁵.\n\nSource: Conversation with Bing, 10/3/2023\n(1) Martin Scorsese reignites MCU feud; supports Christopher Nolan to ‘save cinema’. https://www.msn.com/en-us/movies/news/martin-scorsese-reignites-mcu-feud-supports-christopher-nolan-to-save-cinema/ar-AA1heft5.\n(2) Martin Scorsese Brilliantly Explains MCU Criticisms In New Op-Ed. https://screenrant.com/marvel-movies-martin-scorsese-criticism-response-opinion/.\n(3) Martin Scorsese op-ed clarifies (again) his feelings on MCU and ... - SYFY. https://www.syfy.com/syfywire.com/martin-scorsese-mcu-op-ed.\n(4) You're Missing the Point of Martin Scorsese's Latest Franchise Movie Comments. https://comicbook.com/movies/news/martin-scorsese-comic-book-franchise-movie-comments-opinion-mcu/.\n(5) 10 Controversial Martin Scorsese Moments. https://www.msn.com/en-us/movies/news/10-controversial-martin-scorsese-moments/ar-AA1hulIv.\n(6) Martin Scorsese Makes an Exception for 1 Marvel Franchise in His Criticism."},
            };
            _context.AddRange(Articles);
        }

        if (!_context.Writers.Any())
        {
            var Writers = new List<Writer>()
            {
                new Writer(){ Name = "Greg Hersh"},
                new Writer(){ Name = "Mahmoud Mahdy"},
            };
            _context.AddRange(Writers);
        }

        if (!_context.Comments.Any())
        {
            var Comments = new List<Comment>()
            {
                new Comment(){ Content = "Kendall deserved better", ArticleId = 3},
                new Comment(){ Content = "Martin is right.", ArticleId = 4},
            };
            _context.AddRange(Comments);
        }

        if (!_context.Bookmarks.Any())
        {
            var Bookmarks = new List<Bookmark>()
            {
                new Bookmark(){ WriterId = 6 },
            };
            _context.AddRange(Bookmarks);
        }

        await _context.SaveChangesAsync();
    }
}
