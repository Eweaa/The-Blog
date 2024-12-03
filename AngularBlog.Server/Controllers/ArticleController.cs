using System.Security.Claims;
using BlogApp.Handlers.Articles.Commands;
using BlogApp.Handlers.Articles.Queries;
using Core.DTOs.Article;
using Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace BlogApp.Controllers;

public class ArticleController(ISender sender, UserManager<AppUser> userManager) : BaseController
{
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Guid>> CreateArticle(ArticleToCreate request)
    {
        var userEmail = User.FindFirstValue("Email");
        var userName = User.FindFirstValue("Name");
        
        if (string.IsNullOrEmpty(userEmail) && string.IsNullOrEmpty(userName))
            return Unauthorized();
        
        string filePath = null;
        
        if (request.image != null)
        {
            string fileExtension = request.image.FileName.Split('.').Last();
            filePath = $"wwwroot/images/{request.Title.Replace(" ", "")}.{fileExtension}";
            using (FileStream fileStream = new(filePath, FileMode.Create))
            {
                await request.image.CopyToAsync(fileStream);
            }
        }
        
        CreateArticleCommand command = new() {Title = request.Title, Content = request.Content, ArticleImg = filePath, UserEmail = userEmail, UserName = userName};
        var article = await sender.Send(command);
        return Ok(article);
    }

    [HttpGet]
    public async Task<ActionResult<List<Article>>> GetAllArticles()
    {
        var articles = await sender.Send(new GetAllArticles());
        
        if (articles == null || articles.Count == 0)
            return NotFound();
        
        return Ok(articles);
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<List<Article>>> GetHomeArticles()
    {
        var userName = User.FindFirstValue("Name");

        var test = new GetHomeArticles(userName);
        
        var articles = await sender.Send(new GetHomeArticles(userName));
        
        // var articles = await sender.Send(new GetAllArticles());

        if (articles == null || articles.Count == 0)
            return NotFound();
        
        return Ok(articles);
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<Article>> GetUserArticles(string userProfile)
    {
        var userName = User.FindFirstValue("Name");
        
        GetUserArticles request = new(userProfile, userName!);
        
        var res = await sender.Send(request);
        
        if (res is null)
            return NotFound();
        
        return Ok(res);
    }


    [Authorize]
    [HttpGet]
    public async Task<ActionResult<Article>> GetArticleById(string articleId)
    {
        if (Guid.TryParse(articleId, out Guid guid))
        {
            GetArticleById request = new GetArticleById(guid);
            var res = await sender.Send(request);
            
            if(res is null)
                return NotFound();
            
            return Ok(res);
        }
        else
        {
            return BadRequest();
        }
    }
}