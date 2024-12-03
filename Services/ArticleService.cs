using Core.Contexts;
using Core.DTOs;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Services;

public class ArticleService
{
    private readonly ApplicationDbContext context;

    public ArticleService(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<List<Article>> GetAllArticlesAsync()
    {
        var res =  await context.Articles.ToListAsync();
        return ModifyPath(res);
    }

    public async Task<Article> GetArticleByIdAsync(Guid id)
    {
        var res = await context.Articles.FindAsync(id);
        return MofifyPath(res);
    }

    public async Task<List<Article>> GetMyArticlesAsync(string email)
    {
        var res = await context.Articles.Where(a => a.UserEmail == email).ToListAsync();
        return ModifyPath(res);
    }

    public async Task<UserProfileDto> GetUserArticlesAsync(string userProfile, string userName)
    {
        var user = context.Users.FirstOrDefault(u => u.UserName == userProfile);
        var userImg = user?.UserImg;
        var articles = await context.Articles.Where(a => a.UserName == userProfile).ToListAsync();
        var Follower = await context.Followers.FirstOrDefaultAsync(f => f.UserName == userName && f.FollowedUserName == userProfile);

        bool isFollowing;
        
        if (Follower != null)
            isFollowing = true;
        else
            isFollowing = false;
        
        return new UserProfileDto() { UserName = userProfile, UserImg = Utilities.ModifyPath(userImg), isFollowd = isFollowing, Articles = ModifyPath(articles) };
    }

    public async Task<List<Article>> GetFollowedUsersArticles(string userName)
    {
        var followedUsers = context.Followers.Where(f => f.UserName == userName).Select(f => f.FollowedUserName).ToList();
        
        var articles = await context.Articles.Where(a => followedUsers.Contains(a.UserName)).ToListAsync();
        
        return ModifyPath(articles);
    }

    public async Task<List<Article>> GetBookmarkedArticlesAsync(string userName)
    {
        var bookmarks = await context.Bookmarks.Where(b => b.UserName == userName).Include(b => b.Article).ToListAsync();

        List<Article> articles = new();
        
        foreach (var bookmark in bookmarks)
        {
            bookmark.Article.ArticleImg = Utilities.ModifyPath(bookmark.Article.ArticleImg);
            bookmark.Article.UserImg = Utilities.ModifyPath(bookmark.Article.UserImg);
            articles.Add(bookmark.Article);
        }

        return articles;
    }

    public async Task<bool> AddBookmark(Guid articleId, string userName)
    {
        var bookmark = new Bookmark() { ArticleId = articleId, UserName = userName };
        try
        {
            context.Bookmarks.Add(bookmark);
            await context.SaveChangesAsync();
        }
        catch
        {
            return false;    
        }
        
        return true;
    }

    public async Task<bool> RemoveBookmark(Guid articleId, string userName)
    {
        try
        {
            var bookmark = context.Bookmarks.FirstOrDefault(b => b.UserName == userName && b.ArticleId == articleId);
            context.Bookmarks.Remove(bookmark);
            await context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    private static List<Article> ModifyPath(List<Article> articles)
    {
        foreach (var article in articles)
        {
            if(article.ArticleImg is null)
                continue;
            
            article.ArticleImg = article.ArticleImg.Replace("wwwroot", "https://localhost:7145");
        }

        foreach (var article in articles)
        {
            if(article.UserImg is null)
                continue;
            
            article.UserImg = article.UserImg.Replace("wwwroot", "https://localhost:7145");
        }
        return articles;
    }
    private static Article MofifyPath(Article article)
    {
        if(article.ArticleImg is null)
            return article;
        
        article.ArticleImg = article.ArticleImg.Replace("wwwroot", "https://localhost:7145");
        
        if(article.UserImg is null)
            return article;
        
        article.UserImg = article.UserImg.Replace("wwwroot", "https://localhost:7145");
        
        return article;
    }
}